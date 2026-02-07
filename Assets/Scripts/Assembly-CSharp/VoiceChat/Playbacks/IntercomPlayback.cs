using System.Collections.Generic;
using UnityEngine;

namespace VoiceChat.Playbacks
{
	public class IntercomPlayback : SingleBufferPlayback, IGlobalPlayback
	{
		private bool _isTemplate;

		private ReferenceHub _lastSpeaker;

		private static bool _templateSet;

		private static IntercomPlayback _template;

		private static int _instancesCnt;

		private static readonly List<IntercomPlayback> Instances;

		public bool GlobalChatActive => false;

		public Color GlobalChatColor { get; private set; }

		public string GlobalChatName { get; private set; }

		public float GlobalChatLoudness => 0f;

		public GlobalChatIconType GlobalChatIcon => default(GlobalChatIconType);

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetSpeaker(ReferenceHub speaker)
		{
		}

		public static void ProcessSamples(ReferenceHub ply, float[] samples, int len)
		{
		}
	}
}
