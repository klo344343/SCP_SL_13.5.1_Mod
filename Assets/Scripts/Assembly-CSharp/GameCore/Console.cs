using CommandSystem;
using Mirror;
using Org.BouncyCastle.Crypto;
using PluginAPI.Events;
using RemoteAdmin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ToggleableMenus;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameCore
{
    public class Console : SimpleToggleableMenu
    {
        public enum ConsoleLogType
        {
            DoNotLog = 0,
            Log = 1,
            Warning = 2,
            Error = 3
        }

        public CommandHint[] hints;
        public Text txt;
        public InputField cmdField;

        public static Console singleton { get; private set; }
        public static bool RequestDNT { get; private set; }
        internal static string BinariesRootPath { get; private set; }
        internal static bool DisableSRV { get; private set; }
        internal static bool BindSyncingEnabled { get; set; }
        internal static bool SkipIpValidation { get; private set; }

        public readonly GameConsoleCommandHandler ConsoleCommandHandler = GameConsoleCommandHandler.Create();
        private int _clientCommandPosition;
        private readonly List<string> _clientCommandLogs = new List<string>();

        private static bool _noConsoleLogOutput;
        internal static bool DisplayCreateServer;
        internal static bool TranslationDebugMode;
        internal static AsymmetricKeyParameter _publicKey;
        private static ConsoleCommandSender Ccs;
        internal static string SyncbindPath;
        internal static List<Log> Logs = new List<Log>();
        private static ConcurrentQueue<Log> logQueue = new ConcurrentQueue<Log>();

        private int _scrollup;
        private int _previousScrlup;
        internal static bool _alwaysRefreshing;
        internal static bool _change;
        internal static bool _allowBindSyncing;
        internal static bool _bindSyncingContinue;
        private string _content;

        private StringBuilder _stringBuilder = new StringBuilder();

        private bool GetAllowInput()
        {
            if (cmdField == null) return false;
            return cmdField.isFocused;
        }

        public override bool CanToggle
        {
            get
            {
                if (!IsEnabled)
                    return true;

                if (GetAllowInput())
                    return cmdField.text.Length <= 1;

                return true;
            }
        }

        public override bool LockMovement => false;

        static Console()
        {
            Ccs = new ConsoleCommandSender();
            SyncbindPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCP Secret Laboratory/internal/SyncCmd");
        }

        protected override void Awake()
        {
            base.Awake();
            BinariesRootPath = Path.GetDirectoryName(Path.GetFullPath(Application.dataPath));
            DontDestroyOnLoad(gameObject);

            if (singleton != null && singleton != this)
            {
                DestroyImmediate(gameObject);
                return;
            }

            singleton = this;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            Debug.Log("Hi there! Initializing console...");
            logQueue.Enqueue(new Log("Hi there! Initializing console...", Color.white, false));
            Debug.Log("Done! Type 'help' to print the list of available commands.");
            logQueue.Enqueue(new Log("Done! Type 'help' to print the list of available commands.", Color.white, false));

            CentralAuth.CentralAuthManager.InitAuth();

            Thread thread = new Thread(RefreshPublicKey)
            {
                Name = "Public key refreshing",
                IsBackground = true,
                Priority = System.Threading.ThreadPriority.BelowNormal
            };
            thread.Start();

            string[] args = StartupArgs.Args;

            if (args.Any(arg => string.Equals(arg, "-noconsolelog", StringComparison.OrdinalIgnoreCase)))
            {
                _noConsoleLogOutput = true;
            }

            if (args.Any(arg => string.Equals(arg, "-dnt", StringComparison.OrdinalIgnoreCase)))
            {
                RequestDNT = true;
                Debug.Log("\"Do not track\" request will be sent to all servers you are joining - enabled by startup argument.");
                logQueue.Enqueue(new Log("\"Do not track\" request will be sent to all servers you are joining - enabled by startup argument.", Color.white, false));
            }

            if (args.Any(arg => string.Equals(arg, "-nosrv", StringComparison.OrdinalIgnoreCase)))
            {
                DisableSRV = true;
                Debug.Log("SRV DNS records resolution has been disabled.");
                logQueue.Enqueue(new Log("SRV DNS records resolution has been disabled.", Color.white, false));
            }

            if (args.Any(arg => string.Equals(arg, "-hidetag", StringComparison.OrdinalIgnoreCase)))
            {
                UserSettings.UserSetting<UserSettings.OtherSettings.MiscPrivacySetting>.Set((UserSettings.OtherSettings.MiscPrivacySetting)5, (UserSettings.OtherSettings.MiscPrivacySetting)6);
                Debug.Log("Your global badge will be automatically hidden.");
                logQueue.Enqueue(new Log("Your global badge will be automatically hidden.", Color.white, false));
            }

            if (args.Any(arg => string.Equals(arg, "-neverhidelocaltag", StringComparison.OrdinalIgnoreCase)))
            {
                UserSettings.UserSetting<UserSettings.OtherSettings.MiscPrivacySetting>.Set((UserSettings.OtherSettings.MiscPrivacySetting)6, (UserSettings.OtherSettings.MiscPrivacySetting)6);
                Debug.Log("Your local badge won't be automatically hidden.");
                logQueue.Enqueue(new Log("Your local badge won't be automatically hidden.", Color.white, false));
            }

            if (args.Any(arg => string.Equals(arg, "-hidelocaltag", StringComparison.OrdinalIgnoreCase)))
            {
                UserSettings.UserSetting<UserSettings.OtherSettings.MiscPrivacySetting>.Set((UserSettings.OtherSettings.MiscPrivacySetting)6, (UserSettings.OtherSettings.MiscPrivacySetting)6);
            }

            if (args.Any(arg => string.Equals(arg, "-skipipvalidation", StringComparison.OrdinalIgnoreCase)))
                SkipIpValidation = true;

            if (args.Any(arg => string.Equals(arg, "-scs", StringComparison.OrdinalIgnoreCase)))
                DisplayCreateServer = true;

            if (args.Any(arg => string.Equals(arg, "-allow-syncbind", StringComparison.OrdinalIgnoreCase)))
                _allowBindSyncing = true;

            if (args.Any(arg => string.Equals(arg, "-tdm", StringComparison.OrdinalIgnoreCase)))
                TranslationDebugMode = true;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            string msg = string.Concat("Scene Manager: Loaded scene '", scene.name, "' [", scene.path, "]");
            Debug.Log(msg);
            logQueue.Enqueue(new Log(msg, Color.green, false));
            RefreshConsoleScreen();
        }

        private void Update()
        {
            CentralAuth.CentralAuthManager.Discord?.RunCallbacks();

            if (_change)
            {
                txt.text = _content;
                _change = false;
            }
        }

        private void LateUpdate()
        {
            if (!IsEnabled)
                return;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!string.IsNullOrEmpty(cmdField.text))
                {
                    TypeCommand(cmdField.text);
                    cmdField.text = string.Empty;
                    EventSystem.current.SetSelectedGameObject(cmdField.gameObject);
                }
                cmdField.ActivateInputField();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_clientCommandLogs.Count > _clientCommandPosition)
                {
                    _clientCommandPosition++;
                    int index = _clientCommandLogs.Count - _clientCommandPosition;
                    if (index >= 0)
                        cmdField.text = _clientCommandLogs[index];
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_clientCommandPosition > 0)
                {
                    _clientCommandPosition--;
                    int index = _clientCommandLogs.Count - _clientCommandPosition;
                    if (index < _clientCommandLogs.Count)
                        cmdField.text = _clientCommandLogs[index];
                    else
                        cmdField.text = string.Empty;
                }
            }

            float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * 10f;
            if (scroll != 0)
            {
                _scrollup += (int)scroll;
                if (_scrollup < 0) _scrollup = 0;
                if (_scrollup > Logs.Count) _scrollup = Logs.Count;
            }

            if (_scrollup != _previousScrlup)
            {
                _previousScrlup = _scrollup;
                RefreshConsoleScreen();
            }
        }

        private void FixedUpdate()
        {
            bool logged = false;
            while (logQueue.TryDequeue(out Log log))
            {
                string timeStr = TimeBehaviour.FormatTime("HH:mm:ss");
                string prefix = "<color=#808080><size=18>[" + timeStr + "]</size></color> ";
                string fullMsg = prefix + log.text;

                string[] lines = fullMsg.Split('\n');
                foreach (var line in lines)
                {
                    string cleanLine = line.Replace("\r", string.Empty);
                    Logs.Add(new Log(cleanLine, log.color, log.nospace));
                }
                logged = true;
            }

            if (logged)
            {
                _scrollup = 0;
                RefreshConsoleScreen();
            }
        }

        private void RefreshConsoleScreen()
        {
            if (txt == null) return;
            if (Logs.Count == 0) { _content = string.Empty; _change = true; return; }

            _stringBuilder.Clear();

            int count = 0;
            for (int i = Logs.Count - 1 - _scrollup; i >= 0; i--)
            {
                Log item = Logs[i];
                string line = (count != 0 ? "\n" : "") + "<color=" + Misc.ToHex(item.color) + ">" + item.text + "</color>";

                _stringBuilder.Insert(0, line);
                count++;

                if (_stringBuilder.Length > 15000)
                {
                    Logs.RemoveAt(0);
                    break;
                }
            }

            _content = _stringBuilder.ToString();
            _change = true;
        }

        public static void AddDebugLog(string debugKey, string message, MessageImportance importance, bool nospace = false)
        {
            if (ConsoleDebugMode.CheckImportance(debugKey, importance, out var color))
            {
                AddLog("[DEBUG_" + debugKey + "] " + message, color, nospace);
            }
        }

        public static void AddLog(string text, Color c, bool nospace = false, ConsoleLogType type = ConsoleLogType.Log)
        {
            if (ServerStatic.IsDedicated)
            {
                ServerConsole.AddLog(text, Misc.ClosestConsoleColor(c));
            }

            if (!_noConsoleLogOutput || type != ConsoleLogType.Log)
            {
                switch (type)
                {
                    case ConsoleLogType.Error:
                        Debug.LogError(text);
                        break;
                    case ConsoleLogType.Warning:
                        Debug.LogWarning(text);
                        break;
                    default:
                        Debug.Log(text);
                        break;
                }
            }

            logQueue.Enqueue(new Log(text, c, nospace));
        }

        public static GameObject FindConnectedRoot(NetworkConnection conn)
        {
            try
            {
                GameObject gameObject = conn.identity.gameObject;
                if (gameObject.CompareTag("Player"))
                {
                    return gameObject;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        internal string TypeCommand(string cmd, CommandSender sender = null)
        {
            sender ??= ServerConsole.Scs;

            if (cmd.StartsWith(".", StringComparison.Ordinal) && cmd.Length > 1)
            {
                if (!NetworkClient.active && !NetworkServer.active)
                {
                    AddLog("You must be connected to a server to use this command.", Color.red);
                    return "You must be connected to a server to use remote admin commands!";
                }
                string text = cmd.Substring(1);
                string text2 = "Sending command to server: " + text;
                sender?.Print(text2, ConsoleColor.Green);
                ReferenceHub.LocalHub.gameConsoleTransmission.SendToServer(text);
                return text2;
            }

            bool flag = cmd.StartsWith("@", StringComparison.Ordinal);
            if ((cmd.StartsWith("/", StringComparison.Ordinal) || flag) && cmd.Length > 1)
            {
                string text3 = flag ? cmd : cmd.Substring(1);
                if (!flag)
                {
                    text3 = text3.TrimStart('$');
                    if (string.IsNullOrEmpty(text3))
                    {
                        sender?.Print("Command cant be empty!", ConsoleColor.Green);
                        return "Command cant be empty!";
                    }
                }
                if (NetworkServer.active)
                {
                    if (!flag)
                    {
                        return CommandProcessor.ProcessQuery(text3, sender);
                    }
                    CommandProcessor.ProcessAdminChat(text3.Substring(1), sender);
                    return null;
                }
            }

            string[] array = cmd.Trim().Split(QueryProcessor.SpaceArray, 512, StringSplitOptions.RemoveEmptyEntries);
            if (!EventManager.ExecuteEvent(new ConsoleCommandEvent(sender, array[0], array.Skip(1).ToArray())))
            {
                return null;
            }

            cmd = array[0];
            if (!ConsoleCommandHandler.TryGetCommand(cmd, out var command))
            {
                string text4 = "Command " + cmd + " does not exist!";
                if (!EventManager.ExecuteEvent(new ConsoleCommandExecutedEvent(sender, array[0], array.Skip(1).ToArray(), false, text4)))
                {
                    return null;
                }
                sender?.Print(text4, ConsoleColor.DarkYellow, new Color32(255, 180, 0, 255));
                return text4;
            }

            try
            {
                string response;
                bool flag2 = command.Execute(new ArraySegment<string>(array, 1, array.Length - 1), sender, out response);
                response = Misc.CloseAllRichTextTags(response);
                if (!EventManager.ExecuteEvent(new ConsoleCommandExecutedEvent(sender, array[0], array.Skip(1).ToArray(), flag2, response)))
                {
                    return null;
                }
                if (string.IsNullOrWhiteSpace(response))
                {
                    return null;
                }
                sender?.Print(response, flag2 ? ConsoleColor.Green : ConsoleColor.Red);
                return response;
            }
            catch (Exception ex)
            {
                string text5 = "Command execution failed! Error: " + Misc.RemoveStacktraceZeroes(ex.ToString());
                if (!EventManager.ExecuteEvent(new ConsoleCommandExecutedEvent(sender, array[0], array.Skip(1).ToArray(), false, text5)))
                {
                    return null;
                }
                sender?.Print(text5, ConsoleColor.Red);
                return text5;
            }
        }

        public void ProceedButton()
        {
            if (!string.IsNullOrEmpty(cmdField.text))
            {
                TypeCommand(cmdField.text);
            }
            cmdField.text = string.Empty;
            EventSystem.current.SetSelectedGameObject(cmdField.gameObject);
        }

        internal static void CopyPastebin()
        {
            if (ReferenceHub.TryGetHostHub(out ReferenceHub hub))
            {
                string text = ConfigFile.ServerConfig.GetString("pastebin_read_id", "");
                if (!string.IsNullOrWhiteSpace(text))
                {
                    if (Misc.ValidatePastebin(text))
                    {
                        string url = "https://pastebin.com/raw/" + text;
                        Misc.CopyToClipboard(url);
                        return;
                    }
                    string err = "Pastebin ID is invalid: " + text;
                    Debug.Log(err);
                    logQueue.Enqueue(new Log(err, Color.red, false));
                }
                else
                {
                    Debug.Log("Pastebin is null.");
                    logQueue.Enqueue(new Log("Pastebin is null.", Color.red, false));
                }
            }
            else
            {
                string msg = "Can't find host's reference hub. Please join a server.";
                Debug.Log(msg);
                logQueue.Enqueue(new Log(msg, Color.red, false));
            }
        }

        protected override void OnToggled()
        {
            base.OnToggled();
            cmdField.text = string.Empty;
            if (IsEnabled)
            {
                cmdField.ActivateInputField();
                EventSystem.current.SetSelectedGameObject(cmdField.gameObject);
            }
        }

        private static void RefreshPublicKey()
        {
            while (true)
            {
                try
                {
                    string cache = CentralServerKeyCache.ReadCache();
                    if (!string.IsNullOrEmpty(cache))
                    {
                        _publicKey = Cryptography.ECDSA.PublicKeyFromString(cache);
                        string keyStr = Cryptography.ECDSA.KeyToString(_publicKey);
                        byte[] hash = Cryptography.Sha.Sha256(keyStr);
                        string hashStr = Cryptography.Sha.HashToString(hash);

                        Debug.Log("Loaded central server public key from cache.");
                        logQueue.Enqueue(new Log("Loaded central server public key from cache.", Color.magenta, false));
                        Debug.Log("SHA256 of public key: " + hashStr);
                        logQueue.Enqueue(new Log("SHA256 of public key: " + hashStr, Color.magenta, false));
                    }
                    else
                    {
                        string url = string.Format(CentralServer.StandardUrl, GameCore.Version.Major);
                        string response = HttpQuery.Get(url);
                        PublicKeyResponse respObj = JsonSerialize.FromJson<PublicKeyResponse>(response);

                        if (Cryptography.ECDSA.Verify(respObj.key, respObj.signature, CentralServerKeyCache.MasterKey))
                        {
                            _publicKey = Cryptography.ECDSA.PublicKeyFromString(respObj.key);
                            ServerConsole.PublicKey = _publicKey;

                            string decoded = NorthwoodLib.StringUtils.Base64Decode(respObj.key);
                            CreditsData.LoadData(decoded);

                            string keyStr = Cryptography.ECDSA.KeyToString(_publicKey);
                            byte[] hash = Cryptography.Sha.Sha256(keyStr);
                            string hashStr = Cryptography.Sha.HashToString(hash);

                            Debug.Log("Downloaded public key from central server.");
                            logQueue.Enqueue(new Log("Downloaded public key from central server.", Color.magenta, false));
                            Debug.Log("SHA256 of public key: " + hashStr);
                            logQueue.Enqueue(new Log("SHA256 of public key: " + hashStr, Color.magenta, false));

                            CentralServerKeyCache.SaveCache(respObj.key, respObj.signature);
                        }
                        else
                        {
                            string err = "Can't refresh central server public key - invalid signature!";
                            Debug.Log(err);
                            logQueue.Enqueue(new Log(err, Color.red, false));
                        }
                    }
                    return;
                }
                catch (Exception e)
                {
                    Debug.Log("Can't refresh central server public key!");
                    Debug.Log(e.ToString());
                    logQueue.Enqueue(new Log("Can't refresh central server public key! " + e.Message, Color.red, false));
                    Thread.Sleep(500);
                }
            }
        }

        private void OnApplicationQuit()
        {
            Shutdown.Quit(false, false);
        }
    }
}