using VoiceChat.Networking;

namespace VoiceChat.Playbacks
{
	public class SingleBufferPlayback : VoiceChatPlaybackBase
	{
		private PlaybackBuffer _buffer;

		private bool _bufferSet;

		public PlaybackBuffer Buffer => null;

		public override int MaxSamples => 0;

		private void OnDestroy()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override float ReadSample()
		{
			return 0f;
		}
	}
}
