using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace ServerOutput
{
	public class FileConsole : IServerOutput, IDisposable
	{
		private bool _disposing;

		private uint _logId;

		private readonly string _session;

		private readonly FileSystemWatcher _fsw;

		private readonly Thread _queueThread;

		private readonly ConcurrentQueue<IOutputEntry> _prompterQueue;

		public FileConsole(string session)
		{
		}

		public void Start()
		{
		}

		public void Dispose()
		{
		}

		private void ReadLog(string path)
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

		private void Prompt()
		{
		}
	}
}
