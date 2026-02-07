using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace Respawning.NamingRules
{
	public static class UnitNameMessageHandler
	{
		public static Dictionary<SpawnableTeamType, List<string>> ReceivedNames;

		private static readonly NetworkWriter SendHistory;

		private static readonly SpawnableTeamType[] PregeneratedNameTeams;

		public static event Action<SpawnableTeamType, string, int> OnNameAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		private static void ProcessMessage(UnitNameMessage msg)
		{
		}

		public static string GetReceived(SpawnableTeamType teamType, int unitNameId)
		{
			return null;
		}

		public static void SendNew(SpawnableTeamType team, UnitNamingRule rule)
		{
		}

		public static UnitNameMessage ReadUnitName(this NetworkReader reader)
		{
			return default(UnitNameMessage);
		}

		public static void WriteUnitName(this NetworkWriter writer, UnitNameMessage msg)
		{
		}
	}
}
