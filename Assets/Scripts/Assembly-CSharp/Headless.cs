using UnityEngine;

public static class Headless
{
	public static readonly string version;

	private static bool isHeadless;

	private static bool checkedHeadless;

	private static bool initializedHeadless;

	private static bool buildingHeadless;

	private static bool debuggingHeadless;

	private static HeadlessRuntime headlessRuntime;

	private static string currentProfile;

	public static string GetProfileName()
	{
		return null;
	}

	public static bool IsHeadless()
	{
		return false;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnBeforeSceneLoadRuntimeMethod()
	{
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void OnAfterSceneLoadRuntimeMethod()
	{
	}

	private static void InitializeHeadless()
	{
	}

	private static void HandleLog(string logString, string stackTrace, LogType type)
	{
	}

	public static bool IsBuildingHeadless()
	{
		return false;
	}

	public static bool IsDebuggingHeadless()
	{
		return false;
	}

	public static void SetBuildingHeadless(bool value, string profileName)
	{
	}
}
