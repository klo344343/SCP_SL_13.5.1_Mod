using System;
using System.Collections.Generic;
using Mirror;
using Security;
using UnityEngine;

public class AmbientSoundPlayer : NetworkBehaviour
{
	[Serializable]
	public class AmbientClip
	{
		public AudioClip clip;

		public bool repeatable;

		public bool is3D;

		public bool played;

		public int index;
	}

	public GameObject audioPrefab;

	public int minTime;

	public int maxTime;

	public AmbientClip[] clips;

	private List<AmbientClip> list;

	private RateLimit _ambientSoundRateLimit;

	private void Start()
	{
	}

	private void PlaySound(int clipID)
	{
	}

	private void GenerateRandom()
	{
	}

	[ClientRpc]
	private void RpcPlaySound(int id)
	{
	}

	public override bool Weaved()
	{
		return false;
	}

	protected void UserCode_RpcPlaySound__Int32(int id)
	{
	}

	protected static void InvokeUserCode_RpcPlaySound__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static AmbientSoundPlayer()
	{
	}
}
