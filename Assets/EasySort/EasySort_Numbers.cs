
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
            byte[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<byte> result = new List<byte>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            short[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<short> result = new List<short>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            int[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<int> result = new List<int>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            long[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<long> result = new List<long>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            decimal[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<decimal> result = new List<decimal>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            float[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<float> result = new List<float>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            double[] arrayItems = Sort(items.ToArray(), sortingMethod);
            List<double> result = new List<double>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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