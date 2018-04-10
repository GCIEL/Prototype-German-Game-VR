using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Utils {

    public static void Shuffle<T>(this IList<T> list, System.Random rnd)
    {
        for (var i = 0; i < list.Count; i++)
            list.Swap(i, rnd.Next(i, list.Count));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
