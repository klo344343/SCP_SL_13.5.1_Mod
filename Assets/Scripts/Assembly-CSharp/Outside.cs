using System;
using System.Runtime.CompilerServices;
using CustomRendering;
using UnityEngine;

public class Outside : MonoBehaviour
{
	public static Outside Singleton;

	private FogSetting _fog;

	private Transform listenerPos;

	public bool LocalHostIsOutside => false;

	public static event Action<bool> OnSetOutside
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

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void RefreshCameras()
	{
	}

	private void SetOutside(bool setOutside)
	{
	}
}
