using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{
    public int Hands { get; private set; }
    public int Discards { get; private set; }
    public int PointsToWin { get; set; }

    public event Action<int> HandsValueChanged;
    public event Action<int> DiscradsValueChanged;

    private Round(PlayerProgression progression)
    {
        Hands = progression.Hands.Value;
        Discards = progression.Discards.Value;
    }

    public bool TrySpentHand()
    {
        if (Hands - 1 >= 0)
        {
            Hands--;
            HandsValueChanged?.Invoke(Hands);
            return true;
        }

        return false;
    }

    public bool TrySpentDiscard()
    {
        if (Discards - 1 >= 0)
        {
            Discards--;
            DiscradsValueChanged?.Invoke(Discards);
            return true;
        }

        return false;
    }
}