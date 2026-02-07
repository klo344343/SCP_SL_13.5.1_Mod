using PlayerRoles;
using UnityEngine;
using UnityEngine.UI;

namespace VoiceChat
{
	public class VoiceChatMicrophoneIndicator : MonoBehaviour
	{
		[SerializeField]
		private Image _outline;

		[SerializeField]
		private Image _loudnessIndicator;

		[SerializeField]
		private float _minValue;

		[SerializeField]
		private float _maxValue;

		[SerializeField]
		private float _dropSpeed;

		[SerializeField]
		private float _curvePower;

		private static VoiceChatMicrophoneIndicator _singleton;

		private static bool _singletonSet;

		private float FillAmount
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void UpdateColor(ReferenceHub userHub, PlayerRoleBase prevRole, PlayerRoleBase newRole)
		{
		}

		private void UpdateColor(Graphic target, Color c)
		{
		}

		private void RefreshIndicator(bool isSpeaking, float loudness)
		{
		}

		public static void ShowIndicator(bool isSpeaking, float loudness)
		{
		}
	}
}
