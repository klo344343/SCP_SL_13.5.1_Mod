using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HideHUDController : MonoBehaviour
{
	private static HideHUDController _singleton;

	private bool _showHUDElements;

	public static bool IsHUDVisible => false;

	public static event Action<bool> ToggleHUD
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

	private void Update()
	{
	}
}
