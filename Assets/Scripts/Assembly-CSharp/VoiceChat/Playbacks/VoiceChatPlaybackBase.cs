using UnityEngine;

namespace VoiceChat.Playbacks
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class VoiceChatPlaybackBase : MonoBehaviour
	{
		public float VolumeScale;

		private float _collectedLoudness;

		private int _collectedSamples;

		private float _targetLoudness;

		private const int LoudnessCollectorThreshold = 1200;

		private const float LoudnessCollectorMultiplier = 5f;

		private const float LoudnessLerpSpeed = 40f;

		private static int _flatlinePcmLen;

		private static float[] _flatlinePcm;

		public AudioSource Source { get; private set; }

		public float Loudness { get; private set; }

		public abstract int MaxSamples { get; }

		private static AudioClip Flatline => null;

		private void OnAudioFilterRead(float[] data, int channels)
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		protected abstract float ReadSample();
	}
}
