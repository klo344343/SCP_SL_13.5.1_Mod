using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoiceChat
{
	public static class VoiceChatMutes
	{
		private const string Filename = "mutes.txt";

		private const string IntercomPrefix = "ICOM-";

		private static string _path;

		private static bool _everLoaded;

		private static readonly HashSet<string> Mutes;

		private static readonly Dictionary<ReferenceHub, VcMuteFlags> Flags;

		public static event Action<ReferenceHub, VcMuteFlags> OnFlagsSet
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

		private static void LoadMutes()
		{
		}

		private static bool TryValidateId(string raw, bool intercom, out string validated)
		{
			validated = null;
			return false;
		}

		private static bool TryGetHub(string userId, out ReferenceHub hub)
		{
			hub = null;
			return false;
		}

		private static bool CheckHub(ReferenceHub hub, string id)
		{
			return false;
		}

		private static VcMuteFlags GetLocalFlag(bool intercom)
		{
			return default(VcMuteFlags);
		}

		public static bool QueryLocalMute(string userId, bool intercom = false)
		{
			return false;
		}

		public static void IssueLocalMute(string userId, bool intercom = false)
		{
		}

		public static void RevokeLocalMute(string userId, bool intercom = false)
		{
		}

		public static void SetFlags(ReferenceHub hub, VcMuteFlags flags)
		{
		}

		public static VcMuteFlags GetFlags(ReferenceHub hub)
		{
			return default(VcMuteFlags);
		}

		public static bool IsMuted(ReferenceHub hub, bool checkIntercom = false)
		{
			return false;
		}
	}
}
