using System;
using System.Runtime.InteropServices;
using VoiceChat.Codec.Enums;

namespace VoiceChat.Codec
{
	internal class OpusWrapper
	{
		private const string DllName = "libopus-0";

		[PreserveSig]
		private static extern int opus_encoder_get_size(int channels);

		[PreserveSig]
		private static extern OpusStatusCode opus_encoder_init(IntPtr st, int fs, int channels, OpusApplicationType application);

		[PreserveSig]
		private static extern string opus_get_version_string();

		[PreserveSig]
		private static extern int opus_encode_float(IntPtr st, float[] pcm, int frame_size, byte[] data, int max_data_bytes);

		[PreserveSig]
		private static extern int opus_encoder_ctl(IntPtr st, OpusCtlSetRequest request, int value);

		[PreserveSig]
		private static extern int opus_encoder_ctl(IntPtr st, OpusCtlGetRequest request, ref int value);

		[PreserveSig]
		private static extern int opus_encode(IntPtr st, short[] pcm, int frame_size, byte[] data, int max_data_bytes);

		[PreserveSig]
		private static extern int opus_decoder_get_size(int channels);

		[PreserveSig]
		private static extern OpusStatusCode opus_decoder_init(IntPtr st, int fr, int channels);

		[PreserveSig]
		private static extern int opus_decode(IntPtr st, byte[] data, int len, short[] pcm, int frame_size, int decode_fec);

		[PreserveSig]
		private static extern int opus_decode_float(IntPtr st, byte[] data, int len, float[] pcm, int frame_size, int decode_fec);

		[PreserveSig]
		private static extern int opus_decode(IntPtr st, IntPtr data, int len, short[] pcm, int frame_size, int decode_fec);

		[PreserveSig]
		private static extern int opus_decode_float(IntPtr st, IntPtr data, int len, float[] pcm, int frame_size, int decode_fec);

		[PreserveSig]
		private static extern int opus_packet_get_bandwidth(byte[] data);

		[PreserveSig]
		private static extern int opus_packet_get_nb_channels(byte[] data);

		[PreserveSig]
		private static extern string opus_strerror(OpusStatusCode error);

		public static IntPtr CreateEncoder(int samplingRate, int channels, OpusApplicationType application)
		{
			return (IntPtr)0;
		}

		public static int Encode(IntPtr st, float[] pcm, int frameSize, byte[] data)
		{
			return 0;
		}

		public static int GetEncoderSetting(IntPtr st, OpusCtlGetRequest request)
		{
			return 0;
		}

		public static void SetEncoderSetting(IntPtr st, OpusCtlSetRequest request, int value)
		{
		}

		public static IntPtr CreateDecoder(int samplingRate, int channels)
		{
			return (IntPtr)0;
		}

		public static int Decode(IntPtr st, byte[] data, int dataLength, float[] pcm, bool fec, int channels)
		{
			return 0;
		}

		public static int GetBandwidth(byte[] data)
		{
			return 0;
		}

		public static void HandleStatusCode(OpusStatusCode statusCode)
		{
		}

		public static void Destroy(IntPtr st)
		{
		}
	}
}
