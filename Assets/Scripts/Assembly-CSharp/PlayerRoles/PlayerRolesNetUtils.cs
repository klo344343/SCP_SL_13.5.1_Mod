using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace PlayerRoles
{
	public static class PlayerRolesNetUtils
	{
		public static readonly Dictionary<uint, NetworkReader> QueuedRoles;

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		private static void HandleSpawnedPlayer(ReferenceHub hub)
		{
		}

		public static void WriteRoleSyncInfo(this NetworkWriter writer, RoleSyncInfo info)
		{
		}

		public static RoleSyncInfo ReadRoleSyncInfo(this NetworkReader reader)
		{
			return default(RoleSyncInfo);
		}

		public static void WriteRoleSyncInfoPack(this NetworkWriter writer, RoleSyncInfoPack info)
		{
		}

		public static RoleSyncInfoPack ReadRoleSyncInfoPack(this NetworkReader reader)
		{
			return default(RoleSyncInfoPack);
		}
	}
}
