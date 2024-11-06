using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Casino;

public class Casino_Roulette : MonoBehaviour
{


    public enum RouletteColor { Red, Black, Green }
    public enum RouletteType { American, French }


    public struct RouletteResult
    {
        public string number;
        public int numberValue;
        public RouletteColor rouletteColor;

        public RouletteResult(string number, int numberValue, RouletteColor rouletteColor)
        {
            this.number = number;
            this.numberValue = numberValue;
            this.rouletteColor = rouletteColor;
        }
    }

    private static readonly RouletteResult[] _roulette_American = new RouletteResult[]
    {
        new RouletteResult("0", 0, RouletteColor.Green),
        new RouletteResult("2", 2, RouletteColor.Black),
        new RouletteResult("14", 14, RouletteColor.Red),
        new RouletteResult("35", 35, RouletteColor.Black),
        new RouletteResult("23", 23, RouletteColor.Red),
        new RouletteResult("4", 4, RouletteColor.Black),
        new RouletteResult("16", 16, RouletteColor.Red),
        new RouletteResult("33", 33, RouletteColor.Black),
        new RouletteResult("21", 21, RouletteColor.Red),
        new RouletteResult("6", 6, RouletteColor.Black),
        new RouletteResult("18", 18, RouletteColor.Red),
        new RouletteResult("31", 31, RouletteColor.Black),
        new RouletteResult("19", 19, RouletteColor.Red),
        new RouletteResult("8", 8, RouletteColor.Black),
        new RouletteResult("12", 12, RouletteColor.Red),
        new RouletteResult("29", 29, RouletteColor.Black),
        new RouletteResult("25", 25, RouletteColor.Red),
        new RouletteResult("10", 10, RouletteColor.Black),
        new RouletteResult("27", 27, RouletteColor.Red),
        new RouletteResult("00", -1, RouletteColor.Green),  // "00" represented as -1 for numberValue
        new RouletteResult("1", 1, RouletteColor.Red),
        new RouletteResult("13", 13, RouletteColor.Black),
        new RouletteResult("36", 36, RouletteColor.Red),
        new RouletteResult("24", 24, RouletteColor.Black),
        new RouletteResult("3", 3, RouletteColor.Red),
        new RouletteResult("15", 15, RouletteColor.Black),
        new RouletteResult("34", 34, RouletteColor.Red),
        new RouletteResult("22", 22, RouletteColor.Black),
        new RouletteResult("5", 5, RouletteColor.Red),
        new RouletteResult("17", 17, RouletteColor.Black),
        new RouletteResult("32", 32, RouletteColor.Red),
        new RouletteResult("20", 20, RouletteColor.Black),
        new RouletteResult("7", 7, RouletteColor.Red),
        new RouletteResult("11", 11, RouletteColor.Black),
        new RouletteResult("30", 30, RouletteColor.Red),
        new RouletteResult("26", 26, RouletteColor.Black),
        new RouletteResult("9", 9, RouletteColor.Red),
        new RouletteResult("28", 28, RouletteColor.Black)
    };

    private static readonly RouletteResult[] _roulette_European = new RouletteResult[]
    {
        new RouletteResult("26", 26, RouletteColor.Black),
        new RouletteResult("3", 3, RouletteColor.Red),
        new RouletteResult("35", 35, RouletteColor.Black),
        new RouletteResult("12", 12, RouletteColor.Red),
        new RouletteResult("28", 28, RouletteColor.Black),
        new RouletteResult("7", 7, RouletteColor.Red),
        new RouletteResult("29", 29, RouletteColor.Black),
        new RouletteResult("18", 18, RouletteColor.Red),
        new RouletteResult("22", 22, RouletteColor.Black),
        new RouletteResult("9", 9, RouletteColor.Red),
        new RouletteResult("31", 31, RouletteColor.Black),
        new RouletteResult("14", 14, RouletteColor.Red),
        new RouletteResult("20", 20, RouletteColor.Black),
        new RouletteResult("1", 1, RouletteColor.Red),
        new RouletteResult("33", 33, RouletteColor.Black),
        new RouletteResult("16", 16, RouletteColor.Red),
        new RouletteResult("24", 24, RouletteColor.Black),
        new RouletteResult("5", 5, RouletteColor.Red),
        new RouletteResult("10", 10, RouletteColor.Black),
        new RouletteResult("23", 23, RouletteColor.Red),
        new RouletteResult("8", 8, RouletteColor.Black),
        new RouletteResult("30", 30, RouletteColor.Red),
        new RouletteResult("11", 11, RouletteColor.Black),
        new RouletteResult("36", 36, RouletteColor.Red),
        new RouletteResult("13", 13, RouletteColor.Black),
        new RouletteResult("27", 27, RouletteColor.Red),
        new RouletteResult("6", 6, RouletteColor.Black),
        new RouletteResult("34", 34, RouletteColor.Red),
        new RouletteResult("17", 17, RouletteColor.Black),
        new RouletteResult("25", 25, RouletteColor.Red),
        new RouletteResult("2", 2, RouletteColor.Black),
        new RouletteResult("21", 21, RouletteColor.Red),
        new RouletteResult("4", 4, RouletteColor.Black),
        new RouletteResult("19", 19, RouletteColor.Red),
        new RouletteResult("15", 15, RouletteColor.Black),
        new RouletteResult("32", 32, RouletteColor.Red)
    };


    public static RouletteResult Roulette(RouletteType rouletteType = RouletteType.American)
    {
        if (rouletteType == RouletteType.American)
            return _roulette_American[Random.Range(0, _roulette_American.Length - 1)];
        return _roulette_European[Random.Range(0, _roulette_European.Length - 1)];
    }

}
