using System;
using System.Collections.Generic;

namespace PlayerRoles
{
	public static class PlayerRoleLoader
	{
		private static bool _loaded;

		private static Dictionary<RoleTypeId, PlayerRoleBase> _loadedRoles;

		public static Action OnLoaded;

		public static Dictionary<RoleTypeId, PlayerRoleBase> AllRoles => null;

		public static bool TryGetRoleTemplate<T>(RoleTypeId roleType, out T result) where T : PlayerRoleBase
		{
			result = null;
			return false;
		}

		private static void LoadRoles()
		{
		}
	}
}
