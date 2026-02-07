using System;

namespace ServerOutput
{
	public class NonDedicatedOutput : IServerOutput, IDisposable
	{
		public void Start()
		{
		}

		public void AddLog(string text, ConsoleColor color)
		{
		}

		public void AddLog(string text)
		{
		}

		public void AddOutput(IOutputEntry entry)
		{
		}

		public void Dispose()
		{
		}
	}
}
