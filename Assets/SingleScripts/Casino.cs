using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CoinSide
{
    Heads,
    Tails,
}

public struct WeightedItem<T>
{
    public int Tickets;
    public T Item;

    public WeightedItem(int Tickets, T Item)
    {
        this.Tickets = Tickets;
        this.Item = Item;
    }
}

public static class Casino
{

    /// <summary>
    /// This function gets a random number between 1 and 0 (50/50 chance),
    /// then returns true if the number is equal to 0.
    /// </summary>
    /// <returns></returns>
    // Tested, WORKING
    public static bool CoinFlip()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }


    /// <summary>
    /// Refers to the board game term d20/d10/d6/etc.
    /// <br></br>
    /// You give a number, a range seperator, and optionally specify over / under and equal to the seperator.
    /// <para></para>
    /// If 'overSeperator' is true (default), the dice roll will return true if it hits the rangeSeperator or over
    /// <br></br>
    /// If 'overSeperator' is false, the dice roll will return true if it hits under the rangeSeperator
    /// </summary>
    /// <param name="dSize">The number of sides on the die</param>
    /// <param name="rangeSeperator">The range number to hit below or above</param>
    // Tested, WORKING
    public static bool Roll_dX(int dSize, int rangeSeperator, bool overSeperator = true)
    {
        var outcome = UnityEngine.Random.Range(1, dSize + 1);

        if (overSeperator)
            return outcome >= rangeSeperator;
        else
            return outcome < rangeSeperator;
    }


    /// <summary>
    /// Refers to the board game term d20/d10/d6/etc.
    /// </summary>
    /// <param name="dSize">The number of sides on the die.</param>
    /// <returns>A random number within the sides of the die. (Never zero)</returns>
    // Tested, WORKING
    public static int Roll_dX(int dSize)
    {
        return UnityEngine.Random.Range(1, dSize + 1);
    }

    public static Casino_Roulette.RouletteResult Roulette(Casino_Roulette.RouletteType rouletteType = Casino_Roulette.RouletteType.American)
    {
        return Casino_Roulette.Roulette(rouletteType);
    }

    // Tested, WORKING
    public static T GetOneOfItems<T>(params T[] items)
    {
        return items[UnityEngine.Random.Range(0, items.Length)];
    }

    // Tested, WORKING
    public static T GetOneOfWeightedItems<T>(params WeightedItem<T>[] items)
    {
        int totalTickets = 0;

        for (int i = 0; i < items.Length; i++)
        {
            totalTickets += items[i].Tickets;
        }
        // I was wonering if x should be Range(0, totalTickets + 1) so I'm writing the reason why not here so I don't forget it and wonder the same thing twice:

        // totalTickets = 100
        // x = (0, totalTickets + 1)-1, lands on 100
        // we do x -= tickets for 100 tickets worth
        // x is 0 which is still not below 0
        // we don't output the correct ticketed item, instead reaching the default [0]

        // let's try with excluded highest number
        // totalTickets = 100
        // x = (0, totalTickets)-1, lands on 99
        // we do x -= tickets for 100 tickets worth
        // x is -1 which is below 0
        // worst case scenario we run through all ticketed items but at least the last item is the correct output

        int x = UnityEngine.Random.Range(0, totalTickets);

        for (int j = 0; j < items.Length; j++)
        {
            if ((x -= items[j].Tickets) < 0)
            {
                    Debug.Log("x: " + x);
                return items[j].Item;
            }
        }

        return items[0].Item;
    }
    // Tested, WORKING
    public static TValue GetOneOfWeightedItems<TKey, TValue>(Dictionary<TKey, TValue> ticketsanditems)
    {
        List<WeightedItem<TValue>> weightedItems = new List<WeightedItem<TValue>>();
        try
        {
            foreach (var ticketedpair in ticketsanditems)
            {
                weightedItems.Add(new WeightedItem<TValue>(Convert.ToInt32(ticketedpair.Key), ticketedpair.Value));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("This method requires each key in the Dictionary to be an integer. " + ex.Message);
        }
        return GetOneOfWeightedItems(weightedItems.ToArray());
    }


    // This would would work if it wasn't C#
    /*
    public static T GetOneOfWeightedItems<T>(params T[] ticketsanditems)
    {
        int[] tickets = new int[ticketsanditems.Length / 2];
        T[] items = new T[ticketsanditems.Length / 2];

        try
        {
            for (int i = 0; i < ticketsanditems.Length; i++)
            {
                if (ticketsanditems[i] is int)
                    tickets[i / 2] = Convert.ToInt32(ticketsanditems[i]);
                else
                    items[i / 2] = ticketsanditems[i];
            }
        }
        catch (Exception ex)
        {
            throw new Exception("This method requires each even numbered item in the array to be an integer. " + ex.Message);
        }

        WeightedItem<T>[] weightedItems = new WeightedItem<T>[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            weightedItems[i] = new WeightedItem<T>(tickets[i], items[i]);
        }

        return GetOneOfWeightedItems(weightedItems);

    }
    */




}
