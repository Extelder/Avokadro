using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardHelper
{
    public static int GetCardValue(this Rank rank)
    {
        switch (rank)
        {
            case Rank.J:
            case Rank.Q:
            case Rank.K:
                return 10;

            case Rank.A:
                return 11;

            case Rank.Two: return 2;
            case Rank.Three: return 3;
            case Rank.Four: return 4;
            case Rank.Five: return 5;
            case Rank.Six: return 6;
            case Rank.Seven: return 7;
            case Rank.Eight: return 8;
            case Rank.Nine: return 9;
            case Rank.Ten: return 10;

            default: return 0;
        }
    }
}
