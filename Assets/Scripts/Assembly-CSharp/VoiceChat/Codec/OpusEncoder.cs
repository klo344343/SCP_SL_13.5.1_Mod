using System;
using VoiceChat.Codec.Enums;

namespace VoiceChat.Codec
{
	public class OpusEncoder : IDisposable
	{
		private IntPtr _handle;

		public OpusEncoder(OpusApplicationType preset)
		{
		}

		public int Encode(float[] pcmSamples, byte[] encoded, int frameSize = 480)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
