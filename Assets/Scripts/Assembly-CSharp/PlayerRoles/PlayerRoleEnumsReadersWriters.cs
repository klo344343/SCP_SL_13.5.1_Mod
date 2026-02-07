using Mirror;

namespace PlayerRoles
{
	public static class PlayerRoleEnumsReadersWriters
	{
		public static void WriteRoleType(this NetworkWriter writer, RoleTypeId role)
		{
		}

		public static RoleTypeId ReadRoleType(this NetworkReader reader)
		{
			return default(RoleTypeId);
		}
	}
}
