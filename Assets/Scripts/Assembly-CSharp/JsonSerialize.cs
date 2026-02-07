using System.IO;

public static class JsonSerialize
{
	static JsonSerialize()
	{
	}

	public static string ToJson<T>(T value) where T : IJsonSerializable
	{
		return null;
	}

	public static T FromJson<T>(Stream value) where T : IJsonSerializable
	{
		return default(T);
	}

	public static T FromJson<T>(byte[] value) where T : IJsonSerializable
	{
		return default(T);
	}

	public static T FromJson<T>(byte[] value, int offset) where T : IJsonSerializable
	{
		return default(T);
	}

	public static T FromJson<T>(string value) where T : IJsonSerializable
	{
		return default(T);
	}

	public static T FromFile<T>(string path) where T : IJsonSerializable
	{
		return default(T);
	}
}
