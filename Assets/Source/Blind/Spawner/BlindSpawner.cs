using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class BlindSpawner : IDisposable
{
    private List<IBlindViewable> _blindViews = new List<IBlindViewable>();
    public ReactiveProperty<BlindSelector> Selector { get; private set; } = new ReactiveProperty<BlindSelector>();
    
    public BlindSpawner(BlindConfigsKeeper configsKeeper, BlindSpawnerConfig blindSpawnerConfig, IBlindSpawnerViewable blindSpawnerViewable, BlindView blindView)
    {
        for (int i = 0; i <= blindSpawnerConfig.BlindsCountOnRound; i++)
        {
            Debug.Log("INSTANTIATE");
            IBlindViewable currentBlindViewable = MonoBehaviour.Instantiate(blindView, blindSpawnerViewable.Parent);
            _blindViews.Add(currentBlindViewable);
            currentBlindViewable.Spawned(configsKeeper.SmallBlind);
        }

        if (Selector.Value != null)
            Selector.Dispose();
        Selector.Value = null;
        Selector.Value = new BlindSelector(_blindViews);
    }

    public void Dispose()
    {
    }
}
