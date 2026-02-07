using Mirror;

namespace VoiceChat.Networking
{
	public static class VoiceMessageReadersWriters
	{
		private static readonly byte[] ReceiveArray;

		public static VoiceMessage DeserializeVoiceMessage(this NetworkReader reader)
		{
			return default(VoiceMessage);
		}

		public static void SerializeVoiceMessage(this NetworkWriter writer, VoiceMessage msg)
		{
		}
	}
}
