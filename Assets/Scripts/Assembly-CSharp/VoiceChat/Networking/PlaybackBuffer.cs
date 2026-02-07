using System;
using System.Collections.Generic;

namespace VoiceChat.Networking
{
	public class PlaybackBuffer : IDisposable
	{
		private static readonly Dictionary<int, Queue<float[]>> PoolsOfSize;

		private static float[] _organizerArr;

		private static float _organizerSize;

		private readonly int _bufferSize;

		private readonly bool _endless;

		public long ReadHead;

		public long WriteHead;

		public readonly float[] Buffer;

		public float ReplayVolumeScale { get; set; }

		public int Length => 0;

		public PlaybackBuffer(int capacity = 24000, bool endlessTapeMode = false)
		{
		}

		public void Write(float[] f, int length, int sourceIndex)
		{
		}

		public void Write(float[] f, int length)
		{
		}

		public void Write(float f)
		{
		}

		public float Read()
		{
			return 0f;
		}

		public void ReadTo(float[] arr, long readLength, long destinationIndex = 0L)
		{
		}

		public void Clear()
		{
		}

		public void Reorganize()
		{
		}

		public int AddDelay(int samples, bool force = false)
		{
			return 0;
		}

		public long SyncWith(PlaybackBuffer buffer, int delay = 0)
		{
			return 0L;
		}

		public long HeadToIndex(long headPosition)
		{
			return 0L;
		}

		public void Dispose()
		{
		}
	}
}
