using Mirror;

namespace PlayerRoles
{
	public struct RoleSyncInfoPack : NetworkMessage
	{
		private readonly ReferenceHub _receiverHub;

		public RoleSyncInfoPack(ReferenceHub receiver)
		{
			_receiverHub = null;
		}

		public RoleSyncInfoPack(NetworkReader reader)
		{
			_receiverHub = null;
		}

		public void WritePlayers(NetworkWriter writer)
		{
		}
	}
}
