
using EasySort_Hidden;
using System.Collections.Generic;
using System;

// only for debugging, remove before release !!!
using UnityEngine;






namespace EasySort_Hidden
{
    public static class EasySort_Numbers
    {

        public static List<byte> Sort(List<byte> items, SortingMethod sortingMethod)
        {
            return new List<byte>(Sort(items.ToArray(), sortingMethod));
        }
        public static byte[] Sort(byte[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for short");
            }
        }

        public static List<short> Sort(List<short> items, SortingMethod sortingMethod)
        {
            return new List<short>(Sort(items.ToArray(), sortingMethod));
        }
        public static short[] Sort(short[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for short");
            }
        }
        public static List<int> Sort(List<int> items, SortingMethod sortingMethod)
        {
            return new List<int>(Sort(items.ToArray(), sortingMethod));
        }
        public static int[] Sort(int[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for int");
            }
        }
        public static List<long> Sort(List<long> items, SortingMethod sortingMethod)
        {
            return new List<long>(Sort(items.ToArray(), sortingMethod));
        }
        public static long[] Sort(long[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for long");
            }
        }


        public static List<decimal> Sort(List<decimal> items, SortingMethod sortingMethod)
        {
            return new List<decimal>(Sort(items.ToArray(), sortingMethod));
        }
        public static decimal[] Sort(decimal[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for decimal");
            }
        }

        public static List<float> Sort(List<float> items, SortingMethod sortingMethod)
        {
            return new List<float>(Sort(items.ToArray(), sortingMethod));
        }
        public static float[] Sort(float[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for float");
            }
        }

        public static List<double> Sort(List<double> items, SortingMethod sortingMethod)
        {
            return new List<double>(Sort(items.ToArray(), sortingMethod));
        }
        public static double[] Sort(double[] items, SortingMethod sortingMethod)
        {
            switch (sortingMethod)
            {
                case SortingMethod.BubbleSort:
                    return EasySort_BubbleSort.BubbleSort(items);

                default:
                    throw new NotSupportedException("Sorting method not implemented for double");
            }
        }










    }
}