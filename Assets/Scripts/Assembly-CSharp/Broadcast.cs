using System;
using System.Collections.Generic;
using Mirror;

public class Broadcast : NetworkBehaviour
{
	[Flags]
	public enum BroadcastFlags : byte
	{
		Normal = 0,
		Truncated = 1,
		AdminChat = 2
	}

	private static Broadcast _broadcast;

	private static bool _broadcastSet;

	public static readonly Queue<BroadcastMessage> Messages;

	public static Broadcast Singleton => null;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	[TargetRpc]
	public void TargetAddElement(NetworkConnection conn, string data, ushort time, BroadcastFlags flags)
	{
	}

	[ClientRpc]
	public void RpcAddElement(string data, ushort time, BroadcastFlags flags)
	{
	}

	[TargetRpc]
	public void TargetClearElements(NetworkConnection conn)
	{
	}

	[ClientRpc]
	public void RpcClearElements()
	{
	}

	internal static void AddElement(string data, ushort time, BroadcastFlags flags)
	{
	}

	static Broadcast()
	{
	}

	public override bool Weaved()
	{
		return false;
	}

	protected void UserCode_TargetAddElement__NetworkConnection__String__UInt16__BroadcastFlags(NetworkConnection conn, string data, ushort time, BroadcastFlags flags)
	{
	}

	protected static void InvokeUserCode_TargetAddElement__NetworkConnection__String__UInt16__BroadcastFlags(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	protected void UserCode_RpcAddElement__String__UInt16__BroadcastFlags(string data, ushort time, BroadcastFlags flags)
	{
	}

	protected static void InvokeUserCode_RpcAddElement__String__UInt16__BroadcastFlags(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	protected void UserCode_TargetClearElements__NetworkConnection(NetworkConnection conn)
	{
	}

	protected static void InvokeUserCode_TargetClearElements__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	protected void UserCode_RpcClearElements()
	{
	}

	protected static void InvokeUserCode_RpcClearElements(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}
}
