using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameCore;
using GameObjectPools;
using Mirror;
using PluginAPI.Events;

namespace MapGeneration
{
    public class SeedSynchronizer : NetworkBehaviour
    {
        private const string SeedConfigKey = "map_seed";
        private const string DebugLogChannel = "MAPGEN";
        private const string WarningLogFormat = "<color=orange>Warning:</color> {0}";
        private const string ErrorLogFormat = "<color=red>Fatal Error:</color> {0}";

        private static readonly string[] MapAliases = new string[3] { "LCZ", "HCZ", "EZ" };

        public static bool MapGenerated { get; private set; }

        [SyncVar(hook = nameof(OnSeedChanged))]
        private int _syncSeed;

        private static SeedSynchronizer _singleton;
        private static readonly Stopwatch _stopwatch = new Stopwatch();

        public static float TimeSinceMapGeneration => (float)_stopwatch.Elapsed.TotalSeconds;

        public static int Seed
        {
            get
            {
                if (_singleton != null)
                {
                    return _singleton._syncSeed;
                }
                return 0;
            }
        }

        public static event Action OnMapGenerated;

        private void Awake()
        {
            _singleton = this;
        }

        private void OnDestroy()
        {
            if (_singleton == this)
            {
                _singleton = null;
            }
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            int configSeed = ConfigFile.ServerConfig.GetInt(SeedConfigKey, 0);

            if (configSeed == 0)
            {
                _syncSeed = UnityEngine.Random.Range(0, int.MaxValue);
            }
            else
            {
                _syncSeed = configSeed;
            }

            DebugInfo($"Server started. Selected seed: {_syncSeed}", MessageImportance.Normal);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (_syncSeed != 0)
            {
                GenerateLevel();
            }
        }

        private void OnSeedChanged(int oldSeed, int newSeed)
        {
            if (newSeed != 0)
            {
                GenerateLevel();
            }
        }
        /*
        [ClientRpc]
        private void RpcNotifyMapGenerated()
        {
            OnMapGenerated?.Invoke();
        }
        */
        private void Update()
        {
            if (Seed <= 0 || MapGenerated || ReferenceHub.LocalHub == null)
            {
                return;
            }
            GenerateLevel();
            HashSet<RoomIdentifier> hashSet = new HashSet<RoomIdentifier>();
            foreach (RoomIdentifier allRoomIdentifier in RoomIdentifier.AllRoomIdentifiers)
            {
                if (allRoomIdentifier == null || !allRoomIdentifier.TryAssignId())
                {
                    hashSet.Add(allRoomIdentifier);
                }
            }
            foreach (RoomIdentifier item in hashSet)
            {
                RoomIdentifier.AllRoomIdentifiers.Remove(item);
            }
            EventManager.ExecuteEvent(new MapGeneratedEvent());
            try
            {
                if (NetworkServer.active)
                {
                    PoolManager.Singleton.RestartRound();
                }
                SeedSynchronizer.OnMapGenerated();
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("Failed to call the OnMapGenerated event, error: " + ex.Message);
                UnityEngine.Debug.LogError(ex.StackTrace);
                UnityEngine.Debug.LogError("List of methods that can cause this issue:");
                Delegate[] invocationList = SeedSynchronizer.OnMapGenerated.GetInvocationList();
                foreach (Delegate obj in invocationList)
                {
                    try
                    {
                        obj.Method.Invoke(obj.Target, null);
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("- " + obj.Method.Name);
                    }
                }
            }
            MapGenerated = true;
            _stopwatch.Restart();
        }

        private void GenerateLevel()
        {
            for (int i = 0; i < ImageGenerator.ZoneGenerators.Length; i++)
            {
                string text = MapAliases[i];
                if (ImageGenerator.ZoneGenerators[i].GenerateMap(_syncSeed - i, text, out var blackbox))
                {
                    DebugInfo(text + " generator tasks completed, no fatal errors to report.", MessageImportance.LessImportant);
                }
                else
                {
                    DebugError(isFatal: true, text + " generator tasks failed, blackbox message: " + blackbox);
                }
            }
            DebugInfo("Sequence of procedural level generation completed.", MessageImportance.Normal);
            if (NetworkServer.active)
            {
                DoorSpawnpoint.SetupAllDoors();
            }
        }


        internal static void DebugInfo(string txt, MessageImportance importance, bool nospace = false)
        {
            GameCore.Console.AddDebugLog(DebugLogChannel, txt, importance, nospace);
        }

        internal static void DebugError(bool isFatal, string txt)
        {
            string format = isFatal ? ErrorLogFormat : WarningLogFormat;
            DebugInfo(string.Format(format, txt), MessageImportance.MostImportant);
            UnityEngine.Debug.LogError($"Map generation error for seed {Seed}: {txt}");
        }

        public static void ResetStatus()
        {
            MapGenerated = false;
            _stopwatch.Reset();
        }
    }
}