using UnityEngine;

namespace VoiceChat
{
	public class VoiceChatInGameSettings : MonoBehaviour
	{
		[SerializeField]
		private GameObject _acceptedRoot;

		[SerializeField]
		private GameObject _deniedRoot;

		[SerializeField]
		private bool _updateEveryFrame;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void OnUserFlagsChanged(ReferenceHub hub)
		{
		}

		private void UpdateSettings()
		{
		}

		public void ShowPrivacySettings()
		{
		}
	}
}
