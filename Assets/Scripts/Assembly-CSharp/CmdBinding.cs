using System.Collections.Generic;
using UnityEngine;

public class CmdBinding : MonoBehaviour
{
	public class Bind
	{
		public string command;

		public KeyCode key;
	}

	public static readonly List<Bind> Bindings;

	static CmdBinding()
	{
	}

	private void Update()
	{
	}

	public static void KeyBind(KeyCode code, string cmd)
	{
	}

	public static void Save()
	{
	}

	public static void Load()
	{
	}

	private static void Revent()
	{
	}

	public static void ChangeKeybinding(KeyCode code, string cmd)
	{
	}
}
