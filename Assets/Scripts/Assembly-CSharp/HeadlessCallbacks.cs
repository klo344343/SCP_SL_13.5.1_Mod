using System;
using System.Collections;

public class HeadlessCallbacks : Attribute
{
	private static IEnumerable callbackRegistry;

	public static void FindCallbacks()
	{
	}

	public static void InvokeCallbacks(string callbackName)
	{
	}
}
