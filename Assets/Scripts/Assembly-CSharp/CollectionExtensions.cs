using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

public static class CollectionExtensions
{
	public static void ShuffleList<T>(this IList<T> list)
	{
	}

	public static void ShuffleListSecure<T>(this IList<T> list)
	{
	}

	public static bool IsEmpty(this Array array)
	{
		return false;
	}

	public static bool IsEmpty<T>(this T[] array)
	{
		return false;
	}

	public static bool IsEmpty<T>(this ArraySegment<T> array)
	{
		return false;
	}

	public static bool IsEmpty<T>(this List<T> list)
	{
		return false;
	}

	public static bool IsEmpty<T>(this Queue<T> queue)
	{
		return false;
	}

	public static bool IsEmpty<T>(this Stack<T> stack)
	{
		return false;
	}

	public static bool IsEmpty<T>(this HashSet<T> set)
	{
		return false;
	}

	public static bool IsEmpty<T>(this SortedSet<T> set)
	{
		return false;
	}

	public static bool IsEmpty<T>(this SyncList<T> list)
	{
		return false;
	}

	public static bool IsEmpty<T>(this SyncSet<T> set)
	{
		return false;
	}

	public static bool IsEmpty<TKey, TValue>(this SyncDictionary<TKey, TValue> dictionary)
	{
		return false;
	}

	public static bool IsEmpty<T>(this ICollection<T> collection)
	{
		return false;
	}

	public static bool IsEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
	{
		return false;
	}

	public static bool IsEmpty<T>(this IEnumerable<T> iEnumerable)
	{
		return false;
	}

	public static void EnsureCapacity<T>(this List<T> list, int capacity)
	{
	}

	public static int IndexOf<T>(this T[] array, T obj)
	{
		return 0;
	}

	public static int LastIndexOf<T>(this T[] array, T obj)
	{
		return 0;
	}

	public static bool Contains<T>(this T[] array, T obj)
	{
		return false;
	}

	public static void ForEach<T>(this T[] array, Action<T> obj)
	{
	}

	public static void Reverse<T>(this T[] array)
	{
	}

	public static bool Contains(this string[] array, string str, StringComparison comparison = StringComparison.Ordinal)
	{
		return false;
	}

	public static bool Contains(this List<string> list, string str, StringComparison comparison = StringComparison.Ordinal)
	{
		return false;
	}

	public static bool TryGet<T>(this T[] array, int index, out T element)
	{
		element = default(T);
		return false;
	}

	public static bool TryGet<T>(this List<T> list, int index, out T element)
	{
		element = default(T);
		return false;
	}

	public static bool TryDequeue<T>(this Queue<T> queue, out T element)
	{
		element = default(T);
		return false;
	}

	public static T[] ToArray<T>(this Array array)
	{
		return null;
	}

	public static int IndexOf(this GameObject[] array, GameObject obj)
	{
		return 0;
	}

	public static int IndexOf(this List<GameObject> list, GameObject obj)
	{
		return 0;
	}

	public static bool Contains(this GameObject[] array, GameObject obj)
	{
		return false;
	}

	public static bool Contains(this List<GameObject> list, GameObject obj)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T FirstElement<T>(this ArraySegment<T> segment)
	{
		return default(T);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T At<T>(this ArraySegment<T> segment, int index)
	{
		return default(T);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ArraySegment<T> Segment<T>(this ArraySegment<T> segment, int offset)
	{
		return default(ArraySegment<T>);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ArraySegment<T> Segment<T>(this ArraySegment<T> segment, int offset, int length)
	{
		return default(ArraySegment<T>);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ArraySegment<T> Segment<T>(this T[] array, int offset)
	{
		return default(ArraySegment<T>);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ArraySegment<T> Segment<T>(this T[] array, int offset, int length)
	{
		return default(ArraySegment<T>);
	}

	public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory) where TValue : class
	{
		return null;
	}
}
