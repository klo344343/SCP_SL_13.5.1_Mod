using System.Collections.Generic;
using InventorySystem.Items.Radio;
using Mirror;
using UnityEngine;
using VoiceChat.Networking;

namespace VoiceChat.Playbacks
{
	public class PersonalRadioPlayback : VoiceChatPlaybackBase, IGlobalPlayback
	{
		public struct TransmitterPositionMessage : NetworkMessage
		{
			public RecyclablePlayerId Transmitter;

			public byte WaypointId;
		}

		[SerializeField]
		private AudioSource _noiseSource;

		private int _currentId;

		private bool _hasProximity;

		private bool _isLocalPlayer;

		private bool _recheckCachedRadio;

		private ReferenceHub _owner;

		private RadioItem _cachedRadio;

		private SingleBufferPlayback _proxPlayback;

		private readonly PlaybackBuffer _personalBuffer;

		private const int RadioDelay = 4000;

		private const float ProxVolumeRatio = 0.35f;

		private static PersonalRadioPlayback _localPlayer;

		private static bool _hasLocalPlayer;

		private static int _freeIdsCount;

		private static int _lastTopNumber;

		private static float _noiseLevel;

		private static RadioItem _templateRadio;

		private static bool _templateRadioLoaded;

		private static readonly HashSet<int> FreeIds;

		private int RangeId => 0;

		private RadioItem RadioTemplate => null;

		private static PersonalRadioPlayback LocalPlayer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 LastKnownLocation { get; private set; }

		public int TemporaryId => 0;

		public bool RadioUsable => false;

		public override int MaxSamples => 0;

		public bool GlobalChatActive => false;

		public Color GlobalChatColor => default(Color);

		public string GlobalChatName => null;

		public float GlobalChatLoudness => 0f;

		public GlobalChatIconType GlobalChatIcon => default(GlobalChatIconType);

		private void OnItemsModified(ReferenceHub hub)
		{
		}

		private void UpdateTemporaryId()
		{
		}

		private void UpdateLoudness()
		{
		}

		private void UpdateNoise()
		{
		}

		private bool TryGetUserRadio(out RadioItem radio)
		{
			radio = null;
			return false;
		}

		protected override void OnDisable()
		{
		}

		protected override void Update()
		{
		}

		protected override float ReadSample()
		{
			return 0f;
		}

		public void Setup(ReferenceHub owner, SingleBufferPlayback proximityPlayback)
		{
		}

		public void DistributeSamples(float[] samples, int length)
		{
		}

		public static bool IsTransmitting(ReferenceHub hub)
		{
			return false;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}
	}
}
