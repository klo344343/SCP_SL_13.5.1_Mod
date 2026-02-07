using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VoiceChat.Playbacks;

namespace VoiceChat
{
	public class GlobalChatIndicator : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _nickname;

		[SerializeField]
		private RawImage _icon;

		[SerializeField]
		private Graphic[] _backgrounds;

		[SerializeField]
		private Outline[] _outlines;

		[SerializeField]
		private GameObject _iconRoot;

		[SerializeField]
		private Texture _radioIcon;

		[SerializeField]
		private Texture _intercomIcon;

		private IGlobalPlayback _playback;

		private ReferenceHub _owner;

		private bool _wasSpeaking;

		private float _noSpeakTime;

		private Color _lastColor;

		private Transform _t;

		private const float SustainTime = 0.3f;

		public void Setup(IGlobalPlayback igp, ReferenceHub owner)
		{
		}

		public void Refresh()
		{
		}

		private void SetColors(float loudness)
		{
		}

		private bool TryGetIcon(GlobalChatIconType icon, ReferenceHub owner, out Texture result)
		{
			result = null;
			return false;
		}
	}
}
