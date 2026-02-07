using UnityEngine;

public class ChangeSettingsOnOutside : MonoBehaviour
{
	public bool changeClearFlags;

	private Camera _myCamera;

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void Singleton_OnSetOutside(bool isOutside)
	{
	}
}
