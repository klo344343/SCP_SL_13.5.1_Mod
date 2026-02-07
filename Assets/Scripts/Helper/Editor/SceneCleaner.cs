using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SceneCleaner : EditorWindow
{
    [MenuItem("Tools/Total Scene Cleanup")]
    public static void CleanCurrentScene()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        int lightsFixed = 0;
        int missingScriptsRemoved = 0;
        int hdDataFixed = 0;

        Undo.IncrementCurrentGroup();
        Undo.SetCurrentGroupName("Total Scene Cleanup");

        foreach (var obj in allObjects)
        {
            int missingCount = GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);
            missingScriptsRemoved += missingCount;

            var lights = obj.GetComponents<Light>();
            if (lights.Length > 1)
            {
                for (int i = 1; i < lights.Length; i++)
                {
                    Undo.DestroyObjectImmediate(lights[i]);
                    lightsFixed++;
                }
            }

            var hdDatas = obj.GetComponents<HDAdditionalLightData>();
            if (lights.Length > 0)
            {
                if (hdDatas.Length > 1)
                {
                    for (int i = 1; i < hdDatas.Length; i++)
                    {
                        Undo.DestroyObjectImmediate(hdDatas[i]);
                        hdDataFixed++;
                    }
                }
            }
            else if (hdDatas.Length > 0)
            {
                foreach (var data in hdDatas)
                {
                    Undo.DestroyObjectImmediate(data);
                    hdDataFixed++;
                }
            }
        }

        EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());

        Debug.Log($"<color=orange><b>[Cleanup Done]</b></color> Сцена очищена:\n" +
                  $"- Удалено битых скриптов: {missingScriptsRemoved}\n" +
                  $"- Удалено лишних ламп: {lightsFixed}\n" +
                  $"- Удалено лишних HDRP данных: {hdDataFixed}");

        EditorUtility.DisplayDialog("Чистка завершена",
            $"Сцена: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}\n\n" +
            $"Удалено Missing скриптов: {missingScriptsRemoved}\n" +
            $"Исправлено ламп: {lightsFixed}", "Круто!");
    }
}