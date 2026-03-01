using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CombinationUpgraderHandler : IInitializable, IDisposable
{
    private CombinationContainer _combinationContainer;
    private CombinationUpgrader _combinationUpgrader;

    public CombinationUpgraderHandler(CombinationUpgrader combinationUpgrader,
        CombinationContainer combinationContainer)
    {
        _combinationUpgrader = combinationUpgrader;
        _combinationContainer = combinationContainer;
        _combinationUpgrader.CombinationUpgrade += OnCombinationUpgrade;
    }

    private void OnCombinationUpgrade(int combinationPriority)
    {
        _combinationContainer.CombinationsConfig.Combinations[combinationPriority].CurrentMultiplier.Value += 1;
    }

    public void Initialize()
    {
    }

    public void Dispose()
    {
        _combinationUpgrader.Dispose();
        _combinationUpgrader.CombinationUpgrade -= OnCombinationUpgrade;
    }
}