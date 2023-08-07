
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
    /// If 'overSeperator' is true: outcome is over rangeSeperator?
    /// <br></br>
    /// If 'overSeperator' is false outcome is equal to or under rangeSeperator?
    /// </summary>
    /// <param name="dSize">The number of sides on the die</param>
    /// <param name="rangeSeperator">The range number to hit below or above</param>
    public static bool Roll_dX(int dSize, int rangeSeperator, bool overSeperator = false)
    {
        var outcome = Random.Range(1, dSize + 1);

        // this looks like python lol
        if (overSeperator)
            if (outcome > rangeSeperator)
                return true;
        else
            if (outcome <= rangeSeperator)
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

}
