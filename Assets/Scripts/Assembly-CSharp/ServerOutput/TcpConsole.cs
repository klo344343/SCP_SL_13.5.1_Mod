using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;

namespace ServerOutput
{
	public class TcpConsole : IServerOutput, IDisposable
	{
		public readonly int SpecifiedReceiveBufferSize;

		public readonly int SpecifiedSendBufferSize;

		public const int DefaultReceiveBufferSize = 25000;

		public const int DefaultSendBufferSize = 200000;

		private bool _disposing;

		private readonly ushort _port;

		private readonly int _maxTextLogSize;

		private readonly TcpClient _client;

		private NetworkStream _stream;

		private readonly Thread _receiveThread;

		private readonly Thread _queueThread;

		private readonly ConcurrentQueue<IOutputEntry> _prompterQueue;

		public int ReceiveBufferSize => 0;

		public int SendBufferSize => 0;

		public TcpConsole(ushort port, int receiveBufferSize = 25000, int sendBufferSize = 200000)
		{
		}

		public void Start()
		{
		}

		public void Dispose()
		{
		}

		private void Receive()
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

		private void Send()
		{
		}
	}
}
