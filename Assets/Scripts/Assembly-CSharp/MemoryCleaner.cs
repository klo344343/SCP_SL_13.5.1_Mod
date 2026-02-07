using UnityEngine;
using UnityEngine.SceneManagement;

public static class MemoryCleaner
{
	[RuntimeInitializeOnLoadMethod]
	private static void OnLoad()
	{
	}

	private static void CleanupMemory(Scene scene, LoadSceneMode mode)
	{
	}
}
