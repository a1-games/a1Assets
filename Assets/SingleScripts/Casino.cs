
using UnityEngine;
using UnityEngine.Events;

public enum CoinSide
{
    Heads,
    Tails,
}

public static class Casino
{

    /// <summary>
    /// This function gets a random number between 1 and 0 (50/50 chance),
    /// then returns true if the number is equal to 0.
    /// </summary>
    /// <returns></returns>
    public static bool CoinFlip()
    {
        return Random.Range(0, 2) == 0;
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
    public static bool Roll_dX(int dSize, int rangeSeperator, bool overSeperator = true)
    {
        var outcome = Random.Range(1, dSize + 1);

        // this looks like python lol
        if (overSeperator)
            if (outcome >= rangeSeperator)
                return true;
        else
            if (outcome < rangeSeperator)
                return true;

        return false;
    }


    /// <summary>
    /// Refers to the board game term d20/d10/d6/etc.
    /// </summary>
    /// <param name="dSize">The number of sides on the die.</param>
    /// <returns>A random number within the sides of the die.</returns>
    public static int Roll_dX(int dSize)
    {
        return Random.Range(1, dSize + 1);
    }

    public static void Roulette()
    {

    }





    public static T GetOneOfItems<T>(params T[] ints)
    {
        return ints[Random.Range(0, ints.Length - 1)];
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

    public static T GetOneOfWeightedItems<T>(params WeightedItem<T>[] items)
    {
        int totalTickets = 0;

        for (int i = 0; i < items.Length; i++)
        {
            totalTickets += items[i].Tickets;
        }

        int x = Random.Range(0, totalTickets);

        for (int j = 0; j < items.Length; j++)
        {
            if ((x -= items[j].Tickets) < 0) // Test for A
            {
                return items[j].Item;
            }
        }

        return items[0].Item;
    }








}
