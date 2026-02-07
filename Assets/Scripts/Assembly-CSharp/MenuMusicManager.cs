using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
	private float curState;

	public float lerpSpeed;

	private bool creditsChanged;

	[Space(15f)]
	public AudioSource mainSource;

	public AudioSource creditsSource;

	[Space(8f)]
	public GameObject creditsHolder;

	private void Update()
	{
	}
}
