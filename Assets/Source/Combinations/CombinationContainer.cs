using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationContainer
{
    public CombinationsConfig CombinationsConfig;

    public CombinationContainer(CombinationsConfig combinationsConfig)
    {
        CombinationsConfig = combinationsConfig;
        for (int i = 0; i < CombinationsConfig.Combinations.Length; i++)
        {
            CombinationsConfig.Combinations[i].CurrentMultiplier.Value = CombinationsConfig.Combinations[i].Multiplier;
        }
    }
}