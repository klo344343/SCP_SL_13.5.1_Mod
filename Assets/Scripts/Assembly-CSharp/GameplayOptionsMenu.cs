using UnityEngine;
using UnityEngine.UI;

public class GameplayOptionsMenu : MonoBehaviour
{
	public Slider classIntroFastFadeSlider;

	public Slider headBobSlider;

	public Slider toggleSprintSlider;

	public Slider modeSwitchToggle079;

	public Slider postProcessing079;

	public Slider healthBarShowsExact;

	public Slider richPresence;

	public Slider publicLobby;

	public Slider hideIP;

	public Slider toggleSearch;

	private bool _isAwake;

	public void Awake()
	{
	}

	public void SaveSettings()
	{
	}
}
