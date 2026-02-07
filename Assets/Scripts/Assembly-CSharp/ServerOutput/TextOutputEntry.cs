using System;

namespace ServerOutput
{
	public struct TextOutputEntry : IOutputEntry
	{
		public readonly string Text;

		public readonly byte Color;

		public const int Offset = 5;

		private string HexColor => null;

		public TextOutputEntry(string text, ConsoleColor color)
		{
			Text = null;
			Color = 0;
		}

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
