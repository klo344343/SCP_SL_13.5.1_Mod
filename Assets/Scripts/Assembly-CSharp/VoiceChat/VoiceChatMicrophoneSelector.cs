using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VoiceChat
{
	public class VoiceChatMicrophoneSelector : TMP_Dropdown
	{
		private const string PrefsKeyMicName = "VcMicName";

		private static string _defaultOption;

		private static List<OptionData> _noMicError;

		protected override void Awake()
		{
		}

		private void RefreshOptions()
		{
		}

		private void SetOption(int index, string text)
		{
		}

		private void Update()
		{
		}

		private void OnValueChanged(int i)
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		public static bool TryGetPreferredMicrophone(out string mic)
		{
			mic = null;
			return false;
		}
	}
}
