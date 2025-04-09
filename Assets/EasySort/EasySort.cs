
using System.Collections.Generic;
using EasySort_Hidden;

public enum SortingMethod
{
    AutoSelect,
    // O(1) Space Complexity
    BubbleSort,
    HeapSort,
    ShellSort,
    // O(log(n)) Space Complexity
    QuickSort,
    // O(n) Space Complexity
    BucketSort,
}

public enum StringSortBy
{
    Alphabetic_A_First_Natural,
    Alphabetic_A_Last_Natural,
    Alphabetic_A_First_Ignore_Numbers,
    Alphabetic_A_Last_Ignore_Numbers,
    String_Length_Smallest_First,
    String_Length_Smallest_Last,
}


/////////////////////////////////////////////////////
//                                                 //
//                 EasySort by a1                  //
//                                                 //
// ----------------------------------------------- //
//                                                 //
// Not intended for use every frame.               //
// Sort with caution!                              //
//                                                 //
// I recommend checking this out:                  //
// https://www.bigocheatsheet.com/                 //
//                                                 //
// ----------------------------------------------- //
//                                                 //
// Supported Types:                                //
//                                                 //
// - byte, short, int, long                        //
// - float, double, decimal                        //
// - string, char                                  //
//                                                 //
// - IEasySortable                                 //
//                                                 //
/////////////////////////////////////////////////////


public static class EasySort
{
    private static SortingMethod GetSortingMethod(int count, SortingMethod sortingMethod)
    {
        if (sortingMethod == SortingMethod.AutoSelect)
        {
            sortingMethod = SortingMethod.BubbleSort;
            if (count >= 50)
                sortingMethod = SortingMethod.HeapSort;
        }
        return sortingMethod;
    }

    #region NUMBERS

    // Integer types

    // 8 bit
    public static List<byte> Sort(List<byte> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static byte[] Sort(byte[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    // 16 bit
    public static List<short> Sort(List<short> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static short[] Sort(short[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    // 32 bit
    public static List<int> Sort(List<int> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static int[] Sort(int[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    // 64 bit
    public static List<long> Sort(List<long> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static long[] Sort(long[] items, SortingMethod sortingMethod)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }

    // Floating point types
    // 32 bit
    public static List<double> Sort(List<double> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static double[] Sort(double[] items, SortingMethod sortingMethod)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    // 64 bit
    public static List<float> Sort(List<float> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static float[] Sort(float[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    // 128 bit
    public static List<decimal> Sort(List<decimal> items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Count, sortingMethod));
    }
    public static decimal[] Sort(decimal[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Numbers.Sort(items, GetSortingMethod(items.Length, sortingMethod));
    }
    #endregion

    #region STRINGS

    public static List<string> Sort(List<string> items, StringSortBy stringSortBy, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Strings.Sort(items, stringSortBy, GetSortingMethod(items.Count, sortingMethod));
    }
    public static string[] Sort(string[] items, StringSortBy stringSortBy, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        return EasySort_Strings.Sort(items, stringSortBy, GetSortingMethod(items.Length, sortingMethod));
    }


    #endregion


    #region IEasySortable



    #endregion


























    /*
    public static T[] Sort<T>(T[] items, SortingMethod sortingMethod = SortingMethod.AutoSelect)
    {
        if (items.Length == 0 || items[0] == null)
            throw new ArgumentException("\'items\' is empty or items[0] is null");

        if (sortingMethod == SortingMethod.AutoSelect)
        {
            sortingMethod = SortingMethod.BubbleSort;
            if (items.Length >= 50)
                sortingMethod = SortingMethod.HeapSort;
        }

        Debug.Log(items[0].GetType());
        // Sorted after estimated popularity
        switch (Type.GetTypeCode(items[0].GetType()))
        {
            case TypeCode.Int32:
                return Sort(items, sortingMethod);

            case TypeCode.String:
                return null;

            case TypeCode.Single:
                Debug.Log("float");
                return null;

            case TypeCode.Double:
                Debug.Log("double");
                return null;

            case TypeCode.Boolean:
                return null;


            case TypeCode.Int16:
                Debug.Log("short");
                return null;

            default:
                throw new NotSupportedException("BubbleSort not implemented for this type");
        }

    }

    */









}
