using System.Collections.Generic;
using UnityEngine;

namespace PlayerRoles
{
	public static class RoleTranslations
	{
		private static readonly Dictionary<RoleTypeId, string> TranslatedNames;

		private static readonly Dictionary<RoleTypeId, string> TranslatedAbbreviatedNames;

		public const string RoleNamesFile = "Class_Names";

		public const string AbbreviatedRoleNamesFile = "RA_RoleManagement";

		public static string GetRoleName(RoleTypeId rt)
		{
			return null;
		}

		public static string GetAbbreviatedRoleName(this RoleTypeId rt)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		private static void ReloadNames()
		{
		}
	}
}
