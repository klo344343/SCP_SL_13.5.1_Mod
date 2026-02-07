using VoiceChat.CaressNoiseReduction;

namespace VoiceChat
{
	public static class VoiceChatSettings
	{
		public static readonly float SampleToDuartionRate;

		public const int SampleRate = 48000;

		public const int Channels = 1;

		public const int PacketSizePerChannel = 480;

		public const int BufferLength = 24000;

		public const int NoiseReductionBuffer = 480;

		public const int MaxEncodedSize = 512;

		public const int MaxBitrate = 120000;

		public static readonly NoiseReducerConfig NoiseReductionSettings;
	}
}
