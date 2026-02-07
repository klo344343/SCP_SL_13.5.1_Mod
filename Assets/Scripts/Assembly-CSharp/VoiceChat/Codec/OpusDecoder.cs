using System;

namespace VoiceChat.Codec
{
	public class OpusDecoder : IDisposable
	{
		private IntPtr _handle;

		private bool _previousPacketInvalid;

		public int Decode(byte[] packetData, int dataLength, float[] samples)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
