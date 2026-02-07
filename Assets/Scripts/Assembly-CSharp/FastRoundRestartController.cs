using Mirror;

public class FastRoundRestartController : NetworkBehaviour
{
	private static bool _fastRestartInProgress;

	internal static bool FastRestartInProgress
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public override bool Weaved()
	{
		return false;
	}
}
