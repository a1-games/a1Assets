

using System;
using System.Collections.Generic;

internal class EasySort_Strings
{

    public static List<string> Sort(List<string> items, StringSortBy stringSortBy = StringSortBy.Alphabetic_A_First_Ignore_Numbers)
    {
        return new List<string>(Sort(items.ToArray(), stringSortBy));
    }

    public static string[] Sort(string[] items, StringSortBy stringSortBy)
    {
        switch (stringSortBy)
        {
            // Most expensive to cheapest
            case StringSortBy.Alphabetic_A_First_Natural:
                return Alphabetic_A_First_Natural(items);
            case StringSortBy.Alphabetic_A_Last_Natural:
                return Alphabetic_A_Last_Natural(items);
            case StringSortBy.Alphabetic_A_First_Ignore_Numbers:
                return Alphabetic_A_First_Ignore_Numbers(items);
            case StringSortBy.Alphabetic_A_Last_Ignore_Numbers:
                return Alphabetic_A_Last_Ignore_Numbers(items);
            case StringSortBy.String_Length_Smallest_First:
                return Sort_String_Length_Smallest_First(items);
            case StringSortBy.String_Length_Smallest_Last:
                return Sort_String_Length_Smallest_Last(items);
            default:
                break;
        }
        return items;
    }

    private static string[] Alphabetic_A_First_Natural(string[] items)
    {
        Array.Sort(items, (a, b) =>
        {
            int i = 0, j = 0;

            while (i < a.Length && j < b.Length)
            {
                // Compare digits (number parts)
                if (char.IsDigit(a[i]) && char.IsDigit(b[j]))
                {
                    string numA = ExtractNumber(a, ref i);
                    string numB = ExtractNumber(b, ref j);
                    int numComparison = int.Parse(numA).CompareTo(int.Parse(numB));
                    if (numComparison != 0) return numComparison;
                }
                else
                {
                    // Compare non-digit characters (text parts)
                    int charComparison = a[i].CompareTo(b[j]);
                    if (charComparison != 0) return charComparison;
                    i++;
                    j++;
                }
            }

            return a.Length.CompareTo(b.Length);
        });

        return items;
    }


    private static string[] Alphabetic_A_Last_Natural(string[] items)
    {
        Array.Sort(items, (a, b) =>
        {
            int i = 0, j = 0;

            while (i < a.Length && j < b.Length)
            {
                // Compare digits (number parts)
                if (char.IsDigit(a[i]) && char.IsDigit(b[j]))
                {
                    string numA = ExtractNumber(a, ref i);
                    string numB = ExtractNumber(b, ref j);
                    int numComparison = int.Parse(numA).CompareTo(int.Parse(numB));
                    if (numComparison != 0) return numComparison;
                }
                else
                {
                    // Reverse compare non-digit characters (text parts), so A comes last
                    int charComparison = b[i].CompareTo(a[j]);  // Reverse the comparison order
                    if (charComparison != 0) return charComparison;
                    i++;
                    j++;
                }
            }

            return a.Length.CompareTo(b.Length);
        });

        return items;
    }


    private static string[] Alphabetic_A_First_Ignore_Numbers(string[] items)
    {
        Array.Sort(items, (a, b) =>
        {
            int minLength = Math.Min(a.Length, b.Length);

            for (int i = 0; i < minLength; i++)
            {
                char charA = char.ToLower(a[i]);
                char charB = char.ToLower(b[i]);

                if (charA != charB)
                    return charA.CompareTo(charB);
            }

            return a.Length.CompareTo(b.Length);
        });

        return items;
    }


    private static string[] Alphabetic_A_Last_Ignore_Numbers(string[] items)
    {
        Array.Sort(items, (a, b) =>
        {
            int minLength = Math.Min(a.Length, b.Length);

            for (int i = 0; i < minLength; i++)
            {
                char charA = char.ToLower(a[i]);
                char charB = char.ToLower(b[i]);

                if (charA != charB)
                    return charB.CompareTo(charA);
            }

            return b.Length.CompareTo(a.Length);
        });

        return items;
    }




    private static string[] Sort_String_Length_Smallest_First(string[] items)
    {
        Array.Sort(items, (a, b) => a.Length.CompareTo(b.Length));
        return items;
    }

    private static string[] Sort_String_Length_Smallest_Last(string[] items)
    {
        Array.Sort(items, (a, b) => b.Length.CompareTo(a.Length));
        return items;
    }



    private static string ExtractNumber(string str, ref int i)
    {
        int start = i;
        while (i < str.Length && char.IsDigit(str[i])) i++;
        return str.Substring(start, i - start);
    }

}

