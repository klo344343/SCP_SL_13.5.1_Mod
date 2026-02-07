using PlayerRoles.Voice;
using UnityEngine;

namespace PlayerRoles
{
	public class NoneRole : PlayerRoleBase, IVoiceRole
	{
		[field: SerializeField]
		public VoiceModuleBase VoiceModule { get; private set; }

		public override RoleTypeId RoleTypeId => default(RoleTypeId);

		public override Color RoleColor => default(Color);

		public override Team Team => default(Team);
	}
}
