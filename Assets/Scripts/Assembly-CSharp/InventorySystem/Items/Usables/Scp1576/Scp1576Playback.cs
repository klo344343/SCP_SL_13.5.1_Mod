using System.Collections.Generic;
using GameObjectPools;
using UnityEngine;
using VoiceChat.Playbacks;

namespace InventorySystem.Items.Usables.Scp1576
{
	public class Scp1576Playback : SingleBufferPlayback, IGlobalPlayback, IPoolResettable, IPoolSpawnable
	{
		private static readonly Queue<Scp1576Playback> Pool;

		private static readonly Dictionary<Scp1576Source, Dictionary<ReferenceHub, Scp1576Playback>> ActiveInstances;

		private static bool _anyCreated;

		private static bool _templateCacheSet;

		private static Scp1576Playback _templateCache;

		[SerializeField]
		private bool _playerMode;

		private Transform _tr;

		private Scp1576Source _source;

		private bool _spawned;

		public static Scp1576Playback Template => null;

		public ReferenceHub Owner { get; set; }

		public virtual bool GlobalChatActive => false;

		public virtual Color GlobalChatColor => default(Color);

		public virtual string GlobalChatName => null;

		public virtual float GlobalChatLoudness => 0f;

		public GlobalChatIconType GlobalChatIcon => default(GlobalChatIconType);

		public void SpawnObject()
		{
		}

		public void ResetObject()
		{
		}

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		public static void DistributeSamples(ReferenceHub speaker, float[] samples, int len)
		{
		}

		private static Scp1576Playback GetOrAdd(ReferenceHub player, Scp1576Source source)
		{
			return null;
		}

		private static void ReturnToPool(Scp1576Playback playback)
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}
	}
}
