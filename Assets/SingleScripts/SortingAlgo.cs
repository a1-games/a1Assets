using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SortingAlgo
{
    #region QuickSort
    /// <summary>
    /// Lists are reference types so you don't need ref or return.
    /// </summary>
    /// <param name="numberlist"></param>
    public static void QuickSort(List<int> numberlist)
    {
        quickSort(numberlist, 0, numberlist.Count - 1);
    }
    /// <summary>
    /// Arrays are reference types so you don't need ref or return.
    /// </summary>
    /// <param name="numberlist"></param>
    public static void QuickSort(int[] numberlist)
    {
        quickSort(numberlist, 0, numberlist.Length - 1);
    }

    static void swap(List<int> arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int partition(List<int> arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                swap(arr, i, j);
            }
        }
        swap(arr, i + 1, high);
        return (i + 1);
    }

    static int partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                swap(arr, i, j);
            }
        }
        swap(arr, i + 1, high);
        return (i + 1);
    }

    static void quickSort(List<int> arr, int low, int high)
    {
        if (low < high)
        {
            int pi = partition(arr, low, high);
            quickSort(arr, low, pi - 1);
            quickSort(arr, pi + 1, high);
        }
    }
    static void quickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = partition(arr, low, high);
            quickSort(arr, low, pi - 1);
            quickSort(arr, pi + 1, high);
        }
    }
    #endregion

    // todo:
    // find out which algos are fastest in which size ranges
    //fx:
    // heap sort:
    // 1 - 100
    // bubble sort:
    // 100 - 1000
    // quicksort:
    // 1000 - oo
    // (idk which of these are fastest, thats what needs to be researched

    // and then make a function that uses the fastest algorithm depending on the size of the given array/list
}
