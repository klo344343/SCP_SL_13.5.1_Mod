using Mirror;

internal static class EncryptedChannelFunctions
{
	internal static void SerializeEncryptedMessageOutside(this NetworkWriter writer, EncryptedChannelManager.EncryptedMessageOutside value)
	{
	}

	internal static EncryptedChannelManager.EncryptedMessageOutside DeserializeEncryptedMessageOutside(this NetworkReader reader)
	{
		return default(EncryptedChannelManager.EncryptedMessageOutside);
	}
}
