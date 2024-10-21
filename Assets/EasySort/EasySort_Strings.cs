
using EasySort_Hidden;
using System;
using System.Collections.Generic;

internal class EasySort_Strings
{

    public static List<string> Sort(List<string> items, StringSortBy stringSortBy, SortingMethod sortingMethod)
    {
        string[] arrayItems = Sort(items.ToArray(), stringSortBy, sortingMethod);
        List<string> result = new List<string>();
        for (int i = 0; i < arrayItems.Length; i++)
        {
            result.Add(arrayItems[i]);
        }
        return result;
    }
    public static string[] Sort(string[] items, StringSortBy stringSortBy, SortingMethod sortingMethod)
    {
        switch (sortingMethod)
        {
            case SortingMethod.BubbleSort:
                return EasySort_BubbleSort.BubbleSort(items, stringSortBy);

            default:
                throw new NotSupportedException("Sorting method not implemented for short");
        }
    }
}