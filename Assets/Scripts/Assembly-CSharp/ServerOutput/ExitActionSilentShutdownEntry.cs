using System.Runtime.InteropServices;

namespace ServerOutput
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct ExitActionSilentShutdownEntry : IOutputEntry
	{
		public string GetString()
		{
			return null;
		}

		public int GetBytesLength()
		{
			return 0;
		}

		public void GetBytes(ref byte[] buffer, out int length)
		{
			length = default(int);
		}
	}
}
