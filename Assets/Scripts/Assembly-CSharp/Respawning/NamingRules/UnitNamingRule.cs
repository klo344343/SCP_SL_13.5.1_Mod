using System.Collections.Generic;
using System.Text;
using Mirror;
using PlayerRoles;
using UnityEngine;

namespace Respawning.NamingRules
{
	[SerializeField]
	public abstract class UnitNamingRule
	{
		private static readonly Dictionary<SpawnableTeamType, UnitNamingRule> AllNamingRules;

		public static bool TryGetNamingRule(SpawnableTeamType type, out UnitNamingRule rule)
		{
			rule = null;
			return false;
		}

		public virtual void AppendName(StringBuilder sb, string unitName, RoleTypeId theirRole, PlayerInfoArea infoFlags)
		{
		}

		public virtual string GetCassieUnitName(string regular)
		{
			return null;
		}

		public virtual void PlayEntranceAnnouncement(string regular)
		{
		}

		public abstract void GenerateNew(NetworkWriter writer);

		public abstract string ReadName(NetworkReader reader);

		public abstract int GetRolePower(RoleTypeId role);

		internal void ConfirmAnnouncement(string completeAnnouncement)
		{
		}

		internal void ConfirmAnnouncement(ref StringBuilder sb)
		{
		}
	}
}
