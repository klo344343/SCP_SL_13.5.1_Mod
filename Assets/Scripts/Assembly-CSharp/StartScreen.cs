using System;
using PlayerRoles;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
	[Serializable]
	private struct FadeElement
	{
		public AnimationCurve FadeCurve;

		public CanvasRenderer Renderer;
	}

	private static StartScreen _singleton;

	[SerializeField]
	private int _helpScreenIndex;

	[SerializeField]
	private FadeElement[] _fadeElements;

	[SerializeField]
	private AnimationCurve _fadeLimitNormal;

	[SerializeField]
	private AnimationCurve _fadeLimitFast;

	[SerializeField]
	private AnimationCurve _scaleAnim;

	[SerializeField]
	private AudioSource _bell;

	[SerializeField]
	private Text _roleNameText;

	[SerializeField]
	private Text _roleDescText;

	[SerializeField]
	private Transform _scaler;

	private float _elapsed;

	private float _length;

	private bool _hasHelpMenu;

	private AnimationCurve _limiter;

	public static void Show(PlayerRoleBase prb)
	{
	}

	private void Awake()
	{
	}

	private void Play(PlayerRoleBase prb)
	{
	}

	private void Update()
	{
	}
}
