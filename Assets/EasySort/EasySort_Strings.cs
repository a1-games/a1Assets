
using EasySort_Hidden;
using System;
using System.Collections.Generic;

internal class EasySort_Strings
{

    public static List<string> Sort(List<string> items, StringSortBy stringSortBy, SortingMethod sortingMethod)
    {
        return new List<string>(Sort(items.ToArray(), stringSortBy, sortingMethod));
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

