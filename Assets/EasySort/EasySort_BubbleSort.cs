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
            byte[] arrayItems = BubbleSort(items.ToArray());
            List<byte> result = new List<byte>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            short[] arrayItems = BubbleSort(items.ToArray());
            List<short> result = new List<short>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            int[] arrayItems = BubbleSort(items.ToArray());
            List<int> result = new List<int>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            long[] arrayItems = BubbleSort(items.ToArray());
            List<long> result = new List<long>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            float[] arrayItems = BubbleSort(items.ToArray());
            List<float> result = new List<float>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            double[] arrayItems = BubbleSort(items.ToArray());
            List<double> result = new List<double>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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
            decimal[] arrayItems = BubbleSort(items.ToArray());
            List<decimal> result = new List<decimal>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
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

        #region STRINGS

        public static List<string> BubbleSort(List<string> items, StringSortBy stringSortBy)
        {
            string[] arrayItems = BubbleSort(items.ToArray(), stringSortBy);
            List<string> result = new List<string>();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                result.Add(arrayItems[i]);
            }
            return result;
        }

        public static string[] BubbleSort(string[] items, StringSortBy stringSortBy)
        {
            var n = items.Length;

            switch (stringSortBy)
            {
                case StringSortBy.Alphabetic_A_First:
                    return BubbleSort_Alphabetic_A_First(items);
                case StringSortBy.Alphabetic_A_Last:
                    return BubbleSort_Alphabetic_A_Last(items);

                case StringSortBy.String_Length_Smallest_First:
                    return BubbleSort_String_Length_Smallest_First(items);
                case StringSortBy.String_Length_Smallest_Last:
                    return BubbleSort_String_Length_Smallest_Last(items);

                default:
                    break;
            }


            return items;
        }


        private static string[] BubbleSort_String_Length_Smallest_First(string[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j].Length > items[j + 1].Length)
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        private static string[] BubbleSort_String_Length_Smallest_Last(string[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (items[j].Length < items[j + 1].Length)
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        private static string[] BubbleSort_Alphabetic_A_First(string[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int letterIndex = GetFirstDifferentLetter(items[j], items[j + 1]);
                    // get chars as number since letters should be from a-z
                    int letterLeft = items[j + 1][letterIndex];
                    int letterRight = items[j + 1][letterIndex];

                    if (letterLeft < letterRight)
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        private static string[] BubbleSort_Alphabetic_A_Last(string[] items)
        {
            var n = items.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int letterIndex = GetFirstDifferentLetter(items[j], items[j + 1]);
                    // get chars as number since letters should be from a-z
                    int letterLeft = items[j + 1][letterIndex];
                    int letterRight = items[j + 1][letterIndex];

                    if (letterLeft > letterRight)
                    {
                        var tempVar = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = tempVar;
                    }
                }
            }
            return items;
        }

        private static int GetFirstDifferentLetter(string one, string two)
        {
            int letterIndex = 0;
            // the lowest count is the max so we don't go out of bounds
            int max = one.Length < two.Length ? one.Length : two.Length;
            while (one[letterIndex] == two[letterIndex])
            {
                letterIndex++;
            }
            if (letterIndex < max)
                letterIndex = max - 1;
            return letterIndex < 0 ? 0 : letterIndex;
        }


        #endregion

    }

}


