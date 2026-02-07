using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ShaderUsageCleaner : EditorWindow
{
    private List<ShaderEntry> _allShaders = new List<ShaderEntry>();
    private Vector2 _scrollPos;

    private readonly string[] _ignoreFolders = { "TextMesh Pro", "Editor", "Plugins", "Standard Assets" };

    private class ShaderEntry
    {
        public string Path;
        public string FileName;
        public string InternalName;
        public Shader Asset;
        public bool IsSelected;

        public List<Material> UsedInMaterials = new List<Material>();
        public List<ShaderVariantCollection> UsedInCollections = new List<ShaderVariantCollection>();

        public bool IsPackageDuplicate;
        public bool IsAlwaysIncluded;
        public bool IsTextMeshPro;

        public Shader PackageOriginal; 

        public bool CanBeRemapped => IsPackageDuplicate && PackageOriginal != null && (UsedInMaterials.Count > 0 || UsedInCollections.Count > 0);

        public bool IsSafeToDelete => UsedInMaterials.Count == 0 && UsedInCollections.Count == 0 && !IsAlwaysIncluded && !IsTextMeshPro;
    }

    [MenuItem("Tools/HDRP Ultimate Migrator & Cleaner")]
    public static void ShowWindow() => GetWindow<ShaderUsageCleaner>("Ultimate Cleaner");

    void OnGUI()
    {
        DrawHeader();

        if (GUILayout.Button("🚀 СКАНИРОВАТЬ ПРОЕКТ (FULL SCAN)", GUILayout.Height(40)))
        {
            ScanProject();
        }

        if (_allShaders.Count > 0)
        {
            DrawStats();
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            var toRemap = _allShaders.Where(x => x.CanBeRemapped).ToList();
            if (toRemap.Count > 0)
            {
                DrawSection("🛠️ ТРЕБУЮТ ЗАМЕНЫ НА ОРИГИНАЛ HDRP", toRemap, true);
                GUI.backgroundColor = Color.cyan;
                if (GUILayout.Button($"🪄 ИСПРАВИТЬ ССЫЛКИ В {toRemap.Sum(x => x.UsedInMaterials.Count)} МАТЕРИАЛАХ", GUILayout.Height(35)))
                {
                    RemapAll(toRemap);
                }
                GUI.backgroundColor = Color.white;
            }

            var garbage = _allShaders.Where(x => x.IsSafeToDelete && !x.IsPackageDuplicate).ToList();
            DrawSection("🗑️ МУСОР (НЕ ИСПОЛЬЗУЕТСЯ)", garbage, false);

            var dups = _allShaders.Where(x => x.IsPackageDuplicate && x.IsSafeToDelete).ToList();
            DrawSection("♻️ ДУБЛИКАТЫ ПАКЕТОВ (МОЖНО УДАЛЯТЬ)", dups, false);

            var system = _allShaders.Where(x => x.IsAlwaysIncluded || x.IsTextMeshPro || (!x.IsSafeToDelete && !x.CanBeRemapped)).ToList();
            DrawSection("🛡️ ЗАЩИЩЕНО (ИСПОЛЬЗУЕТСЯ / СИСТЕМНОЕ)", system, false);

            EditorGUILayout.EndScrollView();
            DrawFooter();
        }
    }

    void ScanProject()
    {
        _allShaders.Clear();
        AssetDatabase.SaveAssets();

        var packageShaders = new Dictionary<string, Shader>();
        foreach (var guid in AssetDatabase.FindAssets("t:Shader", new[] { "Packages" }))
        {
            var p = AssetDatabase.GUIDToAssetPath(guid);
            var s = AssetDatabase.LoadAssetAtPath<Shader>(p);
            if (s != null && !packageShaders.ContainsKey(s.name)) packageShaders.Add(s.name, s);
        }

        var includedNames = new HashSet<string>();
        var graphicsSettings = AssetDatabase.LoadAssetAtPath<GraphicsSettings>("ProjectSettings/GraphicsSettings.asset");
        if (graphicsSettings != null)
        {
            var so = new SerializedObject(graphicsSettings);
            var prop = so.FindProperty("m_AlwaysIncludedShaders");
            for (int i = 0; i < prop.arraySize; i++)
            {
                var s = prop.GetArrayElementAtIndex(i).objectReferenceValue as Shader;
                if (s != null) includedNames.Add(s.name);
            }
        }

        var materialMap = new Dictionary<Shader, List<Material>>();
        foreach (var guid in AssetDatabase.FindAssets("t:Material"))
        {
            var p = AssetDatabase.GUIDToAssetPath(guid);
            var mat = AssetDatabase.LoadAssetAtPath<Material>(p);
            if (mat != null && mat.shader != null)
            {
                if (!materialMap.ContainsKey(mat.shader)) materialMap[mat.shader] = new List<Material>();
                materialMap[mat.shader].Add(mat);
            }
        }

        var collectionMap = new Dictionary<Shader, List<ShaderVariantCollection>>();
        foreach (var guid in AssetDatabase.FindAssets("t:ShaderVariantCollection"))
        {
            var p = AssetDatabase.GUIDToAssetPath(guid);
            var svc = AssetDatabase.LoadAssetAtPath<ShaderVariantCollection>(p);
            var deps = AssetDatabase.GetDependencies(p);
            foreach (var d in deps)
            {
                var s = AssetDatabase.LoadAssetAtPath<Shader>(d);
                if (s != null)
                {
                    if (!collectionMap.ContainsKey(s)) collectionMap[s] = new List<ShaderVariantCollection>();
                    collectionMap[s].Add(svc);
                }
            }
        }

        string[] assetsShaders = AssetDatabase.FindAssets("t:Shader", new[] { "Assets" });
        float progress = 0;

        foreach (var guid in assetsShaders)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            EditorUtility.DisplayProgressBar("Анализ...", Path.GetFileName(path), ++progress / assetsShaders.Length);

            if (_ignoreFolders.Any(f => path.Contains(f))) continue;

            var shader = AssetDatabase.LoadAssetAtPath<Shader>(path);
            if (shader == null) continue;

            var entry = new ShaderEntry
            {
                Path = path,
                FileName = Path.GetFileName(path),
                InternalName = GetShaderInternalName(path),
                Asset = shader,
                IsTextMeshPro = path.ToLower().Contains("textmesh pro") || path.Contains("TMP")
            };

            if (string.IsNullOrEmpty(entry.InternalName)) entry.InternalName = shader.name;

            entry.IsAlwaysIncluded = includedNames.Contains(entry.InternalName);

            if (packageShaders.TryGetValue(entry.InternalName, out var original))
            {
                entry.IsPackageDuplicate = true;
                entry.PackageOriginal = original;
            }

            if (materialMap.TryGetValue(shader, out var mats)) entry.UsedInMaterials = mats;
            if (collectionMap.TryGetValue(shader, out var colls)) entry.UsedInCollections = colls;

            if (entry.IsSafeToDelete)
                entry.IsSelected = true;

            _allShaders.Add(entry);
        }
        EditorUtility.ClearProgressBar();
    }

    void RemapAll(List<ShaderEntry> entries)
    {
        int count = 0;
        foreach (var entry in entries)
        {
            foreach (var mat in entry.UsedInMaterials)
            {
                Undo.RecordObject(mat, "Remap Shader to HDRP Original");
                mat.shader = entry.PackageOriginal; 
                EditorUtility.SetDirty(mat);
                count++;
            }
        }
        AssetDatabase.SaveAssets();
        Debug.Log($"<color=green>Успешно исправлено {count} материалов!</color>");
        ScanProject();
    }

    string GetShaderInternalName(string path)
    {
        try
        {
            using (var sr = new StreamReader(path))
            {
                for (int i = 0; i < 50; i++)
                {
                    string line = sr.ReadLine();
                    if (line == null) break;
                    var match = Regex.Match(line, @"Shader\s+""([^""]+)""");
                    if (match.Success) return match.Groups[1].Value;
                }
            }
        }
        catch { }
        return "";
    }

    void DrawSection(string title, List<ShaderEntry> shaders, bool highlight)
    {
        if (shaders.Count == 0) return;
        EditorGUILayout.Space(10);

        var style = new GUIStyle(EditorStyles.boldLabel);
        if (highlight) style.normal.textColor = Color.cyan;

        EditorGUILayout.LabelField(title, style);

        foreach (var s in shaders)
        {
            if (s.CanBeRemapped) GUI.backgroundColor = new Color(0.8f, 1f, 1f); // Голубой (Fix me)
            else if (s.IsPackageDuplicate) GUI.backgroundColor = new Color(1f, 0.8f, 0.8f); // Розоватый (Dup)
            else if (s.IsSafeToDelete) GUI.backgroundColor = Color.white; // Белый (Trash)
            else GUI.backgroundColor = new Color(0.8f, 1f, 0.8f); // Зеленый (Safe)

            EditorGUILayout.BeginHorizontal("helpbox");

            if (s.IsSafeToDelete)
                s.IsSelected = EditorGUILayout.Toggle(s.IsSelected, GUILayout.Width(20));
            else
            {
                GUI.enabled = false;
                EditorGUILayout.Toggle(false, GUILayout.Width(20));
                GUI.enabled = true;
            }

            EditorGUILayout.LabelField(s.FileName, EditorStyles.miniLabel);

            if (s.UsedInMaterials.Count > 0)
                GUILayout.Label($"Mats: {s.UsedInMaterials.Count}", EditorStyles.miniLabel, GUILayout.Width(50));

            if (s.IsAlwaysIncluded)
                GUILayout.Label("SYS", EditorStyles.miniBoldLabel, GUILayout.Width(30));

            if (GUILayout.Button("Find", GUILayout.Width(40))) EditorGUIUtility.PingObject(s.Asset);

            EditorGUILayout.EndHorizontal();
            GUI.backgroundColor = Color.white;
        }
    }

    void DrawHeader()
    {
        EditorGUILayout.Space(10);
        var style = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.MiddleCenter, fontSize = 14 };
        EditorGUILayout.LabelField("🗑️ SCP:SL REVERSE - ULTIMATE CLEANER", style);
        EditorGUILayout.HelpBox("1. Нажми 'Сканировать'.\n2. Если видишь голубую секцию - жми 'Исправить ссылки'.\n3. Жми 'Удалить выбранное' для очистки мусора.", MessageType.Info);
    }

    void DrawStats()
    {
        EditorGUILayout.BeginHorizontal("box");
        GUILayout.Label($"Всего: {_allShaders.Count}");
        GUILayout.Label($"К удалению: {_allShaders.Count(x => x.IsSelected)}");
        GUILayout.Label($"К исправлению: {_allShaders.Count(x => x.CanBeRemapped)}");
        EditorGUILayout.EndHorizontal();
    }

    void DrawFooter()
    {
        EditorGUILayout.Space(10);
        var selected = _allShaders.Where(x => x.IsSelected).ToList();

        GUI.backgroundColor = selected.Count > 0 ? Color.red : Color.gray;
        if (GUILayout.Button($"УНИЧТОЖИТЬ ВЫБРАННЫЕ ({selected.Count})", GUILayout.Height(45)))
        {
            if (selected.Count == 0) return;

            if (EditorUtility.DisplayDialog("Финальная очистка",
                $"Вы удаляете {selected.Count} ассетов.\nОни будут перемещены в корзину.\n\nВы уверены?",
                "УДАЛИТЬ", "Отмена"))
            {
                foreach (var s in selected) AssetDatabase.MoveAssetToTrash(s.Path);
                AssetDatabase.Refresh();
                ScanProject();
            }
        }
        GUI.backgroundColor = Color.white;
    }
}