using Mirror;
using Security;
using UnityEngine;

public class GameConsoleTransmission : NetworkBehaviour
{
	private ReferenceHub _hub;

	private RateLimit _cmdRateLimit;

	private void Start()
	{
	}

	[Server]
	public void SendToClient(string text, string color)
	{
	}

	private static void ClientHandleMessage(string content, EncryptedChannelManager.SecurityLevel securityLevel)
	{
	}

	[Client]
	internal void SendToServer(string command)
	{
	}

	private static void ServerHandleCommand(ReferenceHub hub, string content, EncryptedChannelManager.SecurityLevel securityLevel)
	{
	}

	private static Color ProcessColor(string name)
	{
		return default(Color);
	}

	public override bool Weaved()
	{
		return false;
	}
}
