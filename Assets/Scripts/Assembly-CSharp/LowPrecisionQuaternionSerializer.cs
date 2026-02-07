using Mirror;

public static class LowPrecisionQuaternionSerializer
{
	public static void WriteLowPrecisionQuaternion(this NetworkWriter writer, LowPrecisionQuaternion value)
	{
	}

	public static LowPrecisionQuaternion ReadLowPrecisionQuaternion(this NetworkReader reader)
	{
		return default(LowPrecisionQuaternion);
	}
}
