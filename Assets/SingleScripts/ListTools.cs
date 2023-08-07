using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class ListTools
{

    /// <returns>A jumbled copy of the given list.</returns>
    public static List<T> GetJumbledList<T>(List<T> inputList)
    {

        List<T> jumbledList = new List<T>();
        var count = inputList.Count;

        for (int i = 0; i < count; i++)
        {
            var rnd = UnityEngine.Random.Range(0, inputList.Count);
            jumbledList.Add(inputList[rnd]);
            inputList.RemoveAt(rnd);
        }

        return jumbledList;
    }

    /// <summary>
    /// Jumbles the list passed with 'ref' keyword.
    /// </summary>
    public static void JumbleList<T>(ref List<T> listToJumble)
    {
        List<T> inputList = listToJumble;

        List<T> jumbledList = new List<T>();
        var count = inputList.Count;

        for (int i = 0; i < count; i++)
        {
            var rnd = UnityEngine.Random.Range(0, inputList.Count);
            jumbledList.Add(inputList[rnd]);
            inputList.RemoveAt(rnd);
        }

        listToJumble = jumbledList;
    }
    



    public static void QuickSort<T>(T[] list) where T : IComparable<T>
    {
        QuickSortInternal(list, 0, list.Length - 1);
    }

    private static void QuickSortInternal<T>(T[] list, int left, int right) where T : IComparable<T>
    {
        if (left >= right)
        {
            return;
        }

        int partition = PartitionInternal(list, left, right);

        QuickSortInternal(list, left, partition - 1);
        QuickSortInternal(list, partition + 1, right);
    }

    private static int PartitionInternal<T>(T[] list, int left, int right) where T : IComparable<T>
    {
        T partition = list[right];

        // stack items smaller than partition from left to right
        int swapIndex = left;
        for (int i = left; i < right; i++)
        {
            T item = list[i];
            if (item.CompareTo(partition) <= 0)
            {
                list[i] = list[swapIndex];
                list[swapIndex] = item;

                swapIndex++;
            }
        }

        // put the partition after all the smaller items
        list[right] = list[swapIndex];
        list[swapIndex] = partition;

        return right;
    }

    private static void PrintList<T>(IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            Debug.Log(item);
        }
    }
}
