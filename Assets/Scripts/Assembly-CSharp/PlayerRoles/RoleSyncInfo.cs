using Mirror;

namespace PlayerRoles
{
	public struct RoleSyncInfo : NetworkMessage
	{
		private readonly uint _targetNetId;

		private readonly uint _receiverNetId;

		private readonly PlayerRoleBase _role;

		private readonly RoleTypeId _targetRole;

		public RoleSyncInfo(ReferenceHub target, RoleTypeId role, ReferenceHub receiver)
		{
			_targetNetId = 0u;
			_receiverNetId = 0u;
			_role = null;
			_targetRole = default(RoleTypeId);
		}

		public RoleSyncInfo(NetworkReader reader)
		{
			_targetNetId = 0u;
			_receiverNetId = 0u;
			_role = null;
			_targetRole = default(RoleTypeId);
		}

		public void Write(NetworkWriter writer)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
