using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationContainer
{
    public CombinationsConfig CombinationsConfig;

    public Combination[] Combinations { get; private set; }

    public CombinationContainer(CombinationsConfig combinationsConfig)
    {
        CombinationsConfig = combinationsConfig;
        Combinations = new Combination[CombinationsConfig.Combinations.Length];

        for (int i = 0; i < Combinations.Length; i++)
        {
            Combinations[i] = CombinationsConfig.Combinations[i];
        }

        for (int i = 0; i < CombinationsConfig.Combinations.Length; i++)
        {
            Combinations[i].CurrentMultiplier.Value = CombinationsConfig.Combinations[i].Multiplier;
        }
    }
}