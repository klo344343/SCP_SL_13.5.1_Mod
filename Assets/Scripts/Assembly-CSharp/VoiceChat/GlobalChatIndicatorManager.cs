using System.Collections.Generic;
using UnityEngine;
using VoiceChat.Playbacks;

namespace VoiceChat
{
	public class GlobalChatIndicatorManager : MonoBehaviour
	{
		[SerializeField]
		private GlobalChatIndicator _template;

		[SerializeField]
		private RectTransform _root;

		private readonly Queue<GlobalChatIndicator> _pool;

		private readonly Dictionary<IGlobalPlayback, GlobalChatIndicator> _instances;

		private static GlobalChatIndicatorManager _singleton;

		private static bool _singletonSet;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void SpawnIndicator(IGlobalPlayback igp, ReferenceHub ply)
		{
		}

		private void ReturnIndicator(IGlobalPlayback igp)
		{
		}

		public static void Subscribe(IGlobalPlayback igp, ReferenceHub player)
		{
		}

		public static void Unsubscribe(IGlobalPlayback igp)
		{
		}
	}
}
