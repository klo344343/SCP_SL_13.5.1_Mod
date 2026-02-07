using RelativePositioning;
using UnityEngine;

public class MovementTracer
{
	public byte Clock;

	public readonly RelativePosition[] Positions;

	private readonly byte _size;

	private readonly byte _cooldown;

	private readonly float _tpDis;

	private byte _cooldownTimer;

	public MovementTracer(byte size, byte cooldown, float teleportDistance)
	{
	}

	public void Record(Vector3 plyPosition)
	{
	}

	public Bounds GenerateBounds(float time, bool ignoreTeleports)
	{
		return default(Bounds);
	}
}
