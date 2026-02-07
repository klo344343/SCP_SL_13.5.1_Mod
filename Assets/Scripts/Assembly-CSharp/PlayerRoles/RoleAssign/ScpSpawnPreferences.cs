using System.Collections.Generic;
using Mirror;
using PlayerRoles.PlayableScps;
using UnityEngine;

namespace PlayerRoles.RoleAssign
{
    public static class ScpSpawnPreferences
    {
        public readonly struct SpawnPreferences : NetworkMessage
        {
            private readonly byte _count;

            public readonly Dictionary<RoleTypeId, int> Preferences;

            public SpawnPreferences(bool autoSetup)
            {
                _count = 0;
                Preferences = new Dictionary<RoleTypeId, int>();
                if (!autoSetup)
                {
                    return;
                }
                foreach (KeyValuePair<RoleTypeId, PlayerRoleBase> allRole in PlayerRoleLoader.AllRoles)
                {
                    if (allRole.Value is ISpawnableScp)
                    {
                        Preferences[allRole.Key] = GetPreference(allRole.Key);
                        _count++;
                    }
                }
            }

            public SpawnPreferences(NetworkReader reader)
            {
                _count = reader.ReadByte();
                Preferences = new Dictionary<RoleTypeId, int>(_count);
                for (int i = 0; i < _count; i++)
                {
                    RoleTypeId key = reader.ReadRoleType();
                    int val = reader.ReadSByte();
                    Preferences[key] = ClampPreference(val);
                }
            }

            public void Serialize(NetworkWriter writer)
            {
                writer.WriteByte(_count);
                foreach (KeyValuePair<RoleTypeId, int> preference in Preferences)
                {
                    writer.WriteRoleType(preference.Key);
                    writer.WriteSByte((sbyte)preference.Value);
                }
            }
        }

        public static readonly Dictionary<NetworkConnectionToClient, SpawnPreferences> Preferences = new Dictionary<NetworkConnectionToClient, SpawnPreferences>();

        public const int MaxPreference = 5;

        private const string PrefsPrefix = "SpawnPreference_Role_";

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            CustomNetworkManager.OnClientReady += delegate
            {
                Preferences.Clear();
                NetworkServer.ReplaceHandler<SpawnPreferences>(OnMessageReceived);
                NetworkClient.Send(new SpawnPreferences(autoSetup: true));
                NetworkServer.OnDisconnectedEvent += OnClientDisconnected;
            };
        }

        private static void OnClientDisconnected(NetworkConnectionToClient conn)
        {
            Preferences.Remove(conn);
        }

        private static int ClampPreference(int val)
        {
            return Mathf.Clamp(val, -5, 5);
        }

        private static void OnMessageReceived(NetworkConnectionToClient conn, SpawnPreferences msg)
        {
            Preferences[conn] = msg;
        }

        public static int GetPreference(RoleTypeId role)
        {
            int num = (int)role;
            return ClampPreference(PlayerPrefsSl.Get(PrefsPrefix + num, 0));
        }

        public static void SavePreference(RoleTypeId role, int value)
        {
            int num = (int)role;
            PlayerPrefsSl.Set(PrefsPrefix + num, value);
            if (NetworkClient.active)
            {
                NetworkClient.Send(new SpawnPreferences(autoSetup: true));
            }
        }

        public static void WriteSpawnPreferences(this NetworkWriter writer, SpawnPreferences msg)
        {
            msg.Serialize(writer);
        }

        public static SpawnPreferences ReadSpawnPreferences(this NetworkReader reader)
        {
            return new SpawnPreferences(reader);
        }
    }
}
