using UnityEngine;
using UserSettings;
using VoiceChat.CaressNoiseReduction;
using VoiceChat.Networking;

namespace VoiceChat
{
	public class VoiceChatMicCapture : MonoBehaviour
	{
		private static VoiceChatMicCapture _singleton;

		private static bool _singletonSet;

		private static string _selectedMic;

		private NoiseReducer _noiseReducer;

		private PlaybackBuffer _recordBuffer;

		private PlaybackBuffer _sendBuffer;

		private AudioSource _micSource;

		private VoiceChatChannel _channel;

		private float[] _noiseReductionBuffer;

		private float[] _samples;

		private int _lastSample;

		private int _samplesCount;

		private bool _micStarted;

		private bool _noiseReductionFailed;

		private static readonly CachedUserSetting<bool> NoiseSuppressionSetting;

		private static bool MicCaptureDenied => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void OnPrivacySettingsUpdated(ReferenceHub hub)
		{
		}

		private bool UpdateRecording(out float loudness, out bool isSpeaking)
		{
			loudness = default(float);
			isSpeaking = default(bool);
			return false;
		}

		public static void StopAllMicrophones()
		{
		}

		public static void StartRecording()
		{
		}

		public static void RestartRecording()
		{
		}

		public static VoiceChatChannel GetCurrentChannel()
		{
			return default(VoiceChatChannel);
		}
	}
}
