using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirror;
using ToggleableMenus;
using UnityEngine;
using UnityEngine.UI;

namespace VoiceChat
{
	public class VoiceChatPrivacySettings : ToggleableMenuBase
	{
		[Serializable]
		private class ToggleGroup
		{
			[field: SerializeField]
			public Toggle AcceptToggle { get; private set; }

			[field: SerializeField]
			public Toggle DenyToggle { get; private set; }

			[field: SerializeField]
			public VcPrivacyFlags Flags { get; private set; }

			public bool IsAccepted
			{
				get
				{
					return false;
				}
				set
				{
				}
			}
		}

		public struct VcPrivacyMessage : NetworkMessage
		{
			public byte Flags;
		}

		[SerializeField]
		private GameObject _simplifiedRoot;

		[SerializeField]
		private GameObject _advancedRoot;

		[SerializeField]
		private Canvas _hideHudCanvas;

		[SerializeField]
		private Image _recordDim;

		[SerializeField]
		private Image _dimmerBackground;

		[SerializeField]
		private GameObject _returnButton;

		[SerializeField]
		private ToggleGroup[] _groups;

		private readonly Dictionary<VcPrivacyFlags, ToggleGroup> _groupsByFlags;

		private static readonly Dictionary<ReferenceHub, VcPrivacyFlags> FlagsOfPlayers;

		private const string PrefsKey = "VcPrivacyFlags_1.1";

		private bool _forceOpen;

		private static VcPrivacyFlags _loadedFlags;

		private static bool _flagsLoaded;

		public static VoiceChatPrivacySettings Singleton { get; private set; }

		public override bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool CanToggle => false;

		private static VcPrivacyFlags PrefsFlags
		{
			get
			{
				return default(VcPrivacyFlags);
			}
			set
			{
			}
		}

		public static VcPrivacyFlags PrivacyFlags
		{
			get
			{
				return default(VcPrivacyFlags);
			}
			set
			{
			}
		}

		public static event Action<ReferenceHub> OnUserFlagsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnToggled()
		{
		}

		public void UpdateToggles()
		{
		}

		public void HandleToggle(Toggle checkbox)
		{
		}

		public void Open(bool advanced, bool forceOpen)
		{
		}

		public void Close()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
		}

		public static bool CheckUserFlags(ReferenceHub user, VcPrivacyFlags flags)
		{
			return false;
		}
	}
}
