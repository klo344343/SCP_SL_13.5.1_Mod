using System.Collections.Generic;
using UnityEngine;
using VoiceChat.Networking;

namespace VoiceChat.Playbacks
{
	public class SpatializedRadioPlaybackBase : VoiceChatPlaybackBase
	{
		private Transform _t;

		private const int MaxAudibleRadios = 4;

		private static readonly SpatializedRadioPlaybackBase[] AudibleRadioInst;

		private static readonly float[] AudibleRadiosDis;

		public const int MaxSignals = 8;

		public PlaybackBuffer[] Buffers;

		public int RangeId;

		public uint IgnoredNetId;

		public static readonly HashSet<SpatializedRadioPlaybackBase> AllInstances;

		[field: SerializeField]
		public AudioSource NoiseSource { get; private set; }

		public Vector3 LastPosition { get; private set; }

		public bool Culled { get; private set; }

		public override int MaxSamples => 0;

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
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

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}
	}
}
