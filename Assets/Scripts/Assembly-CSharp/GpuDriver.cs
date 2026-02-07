using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class GpuDriver
{
	private const string Library = "GpuDriver.dll";

	private const CallingConvention CallingConv = CallingConvention.StdCall;

	private static string _driverVersion;

	private static readonly object _dataLock;

	public static string DriverVersion => null;

	public static event Action<string> DriverLoaded
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

	[PreserveSig]
	private static extern IntPtr GetDriverVersion(string name);

	[PreserveSig]
	private static extern void Free(IntPtr version);
}
