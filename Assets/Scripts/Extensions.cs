using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool CheckLength<T>(this T[] array)
    {
        if (array.Length > 0) return true;
        else return false;
    }
    public static void SetList<T>(this List<T> list, T[] array)
    {
        foreach (var elem in array)
        {
            list.Add(elem);
        }
    }
    public static void DoForAll<T>(this IEnumerable<T> list, Action<T> predicate)
    {
        foreach (var elem in list)
        {
            predicate(elem);
        }
    }
}
