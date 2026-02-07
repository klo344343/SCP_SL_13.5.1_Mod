using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirror;
using PlayerRoles;
using UnityEngine;

namespace InventorySystem.Items.Usables
{
	public static class UsableItemsController
	{
		public static readonly Dictionary<ReferenceHub, PlayerHandler> Handlers;

		public static readonly Dictionary<ushort, float> GlobalItemCooldowns;

		public static readonly Dictionary<ushort, float> StartTimes;

		private static readonly Dictionary<ushort, AudioSource> CurrentlyPlayingSources;

		public static event Action<ReferenceHub, UsableItem> ServerOnUsingCompleted
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

		public static event Action<StatusMessage> OnClientStatusReceived
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
		private static void InitOnLoad()
		{
		}

		public static void OnClientReady()
		{
		}

		public static PlayerHandler GetHandler(ReferenceHub ply)
		{
			return null;
		}

		public static float GetCooldown(ushort itemSerial, ItemBase item, PlayerHandler ply)
		{
			return 0f;
		}

		public static void PlaySoundOnPlayer(ReferenceHub ply, AudioClip clip)
		{
		}

		private static void Update()
		{
		}

		private static void ServerReceivedStatus(NetworkConnection conn, StatusMessage msg)
		{
		}

		private static void ClientReceivedStatus(StatusMessage msg)
		{
		}

		private static void ClientReceivedCooldown(ItemCooldownMessage msg)
		{
		}

		private static void ResetPlayerOnRoleChange(ReferenceHub ply, PlayerRoleBase r1, PlayerRoleBase r2)
		{
		}
	}
}
