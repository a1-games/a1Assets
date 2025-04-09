using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace EasySort_Hidden
{
    internal class EasySort_BubbleSort
    {
        #region NUMBERS

        // Integer types

        public static List<byte> BubbleSort(List<byte> items)
        {
            return new List<byte>(BubbleSort(items.ToArray()));
        }
        public static byte[] BubbleSort(byte[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        public static List<short> BubbleSort(List<short> items)
        {
            return new List<short>(BubbleSort(items.ToArray())); ;
        }
        public static short[] BubbleSort(short[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        public static List<int> BubbleSort(List<int> items)
        {
            return new List<int>(BubbleSort(items.ToArray()));
        }
        public static int[] BubbleSort(int[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        public static List<long> BubbleSort(List<long> items)
        {
            return new List<long>(BubbleSort(items.ToArray()));
        }
        public static long[] BubbleSort(long[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        // Floating point types

        public static List<float> BubbleSort(List<float> items)
        {
            return new List<float>(BubbleSort(items.ToArray()));
        }
        public static float[] BubbleSort(float[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        public static List<double> BubbleSort(List<double> items)
        {
            return new List<double>(BubbleSort(items.ToArray()));
        }
        public static double[] BubbleSort(double[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }


        public static List<decimal> BubbleSort(List<decimal> items)
        {
            return new List<decimal>(BubbleSort(items.ToArray()));
        }
        public static decimal[] BubbleSort(decimal[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }
        #endregion




    }

}


