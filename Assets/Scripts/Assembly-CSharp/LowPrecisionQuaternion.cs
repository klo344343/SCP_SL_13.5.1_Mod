using System;
using UnityEngine;

public readonly struct LowPrecisionQuaternion : IEquatable<LowPrecisionQuaternion>
{
	private const sbyte Range = sbyte.MaxValue;

	private readonly sbyte _x;

	private readonly sbyte _y;

	private readonly sbyte _z;

	private readonly sbyte _w;

	public Quaternion Value => default(Quaternion);

	public LowPrecisionQuaternion(Quaternion value)
	{
		_x = 0;
		_y = 0;
		_z = 0;
		_w = 0;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public static bool operator ==(LowPrecisionQuaternion left, LowPrecisionQuaternion right)
	{
		return false;
	}

	public static bool operator !=(LowPrecisionQuaternion left, LowPrecisionQuaternion right)
	{
		return false;
	}

	public bool Equals(LowPrecisionQuaternion other)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}
}
