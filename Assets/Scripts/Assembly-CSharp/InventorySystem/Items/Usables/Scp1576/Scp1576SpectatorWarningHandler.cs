using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace InventorySystem.Items.Usables.Scp1576
{
	public static class Scp1576SpectatorWarningHandler
	{
		public struct SpectatorWarningMessage : NetworkMessage
		{
			public bool IsStop;
		}

		private static readonly Stopwatch CooldownTimer;

		private static readonly HashSet<ushort> CurrentlyUsed;

		private static bool _stopSoundScheduled;

		public static event Action OnStart
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

		public static event Action OnStop
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

		private static void SendMessage(bool isStop)
		{
		}

		private static void HandleMessage(SpectatorWarningMessage msg)
		{
		}

		public static void TriggerStart(Scp1576Item item)
		{
		}

		public static void TriggerStop(Scp1576Item item)
		{
		}
	}
}
