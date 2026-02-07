using System.Collections.Generic;
using Mirror;
using UnityEngine;
using VoiceChat.Codec;

namespace VoiceChat.Networking
{
	public static class VoiceTransceiver
	{
		private static readonly List<OpusEncoder> Encoders;

		private static int _encodersCount;

		private static int _packageSize;

		private static float[] _sendBuffer;

		private static byte[] _encodedBuffer;

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		private static void ServerReceiveMessage(NetworkConnection conn, VoiceMessage msg)
		{
		}

		private static void ClientReceiveMessage(VoiceMessage msg)
		{
		}

		public static void ClientSendData(PlaybackBuffer micBuffer, VoiceChatChannel targetChannel, int encoderId = 0)
		{
		}
	}
}
