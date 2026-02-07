using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mirror;

public class AspectRatioSync : NetworkBehaviour
{
	private static float _defaultCameraFieldOfView;

	private int _savedWidth;

	private int _savedHeight;

	public static float YScreenEdge { get; private set; }

	[field: SyncVar]
	public float XScreenEdge { get; private set; }

	public float XplusY { get; private set; }

	public float AspectRatio { get; private set; }

	public float Network_003CXScreenEdge_003Ek__BackingField
	{
		get
		{
			return 0f;
		}
		[param: In]
		set
		{
		}
	}

	public static event Action OnAspectRatioChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	private void UpdateAspectRatio()
	{
	}

	private void FixedUpdate()
	{
	}

	[Command(channel = 4)]
	private void CmdSetAspectRatio(float aspectRatio)
	{
	}

	static AspectRatioSync()
	{
	}

	public override bool Weaved()
	{
		return false;
	}

	protected void UserCode_CmdSetAspectRatio__Single(float aspectRatio)
	{
	}

	protected static void InvokeUserCode_CmdSetAspectRatio__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}
}
