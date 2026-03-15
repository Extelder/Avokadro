using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class BlindSpawner : IDisposable
{
    private BlindSortSpawner _blindSortSpawner;
    private BlindSpawnerView _blindSpawnerView;
    private BlindView _view;
    private List<IBlindViewable> _blindViews = new List<IBlindViewable>();
    public ReactiveProperty<BlindSelector> Selector { get; private set; } = new ReactiveProperty<BlindSelector>();

    public BlindSpawner(BlindSortSpawner blindSortSpawner, BlindSpawnerView blindSpawnerView, BlindView blindView)
    {
        _blindSpawnerView = blindSpawnerView;
        _blindSortSpawner = blindSortSpawner;
        _view = blindView;
        _blindSortSpawner.BlindAdded += OnBlindAdded;
    }

    private void OnBlindAdded(List<BlindConfig> blindSpawnerConfig)
    {
        for (int i = 0; i < blindSpawnerConfig.Count; i++)
        {
            IBlindViewable currentBlindViewable = MonoBehaviour.Instantiate(_view, _blindSpawnerView.Parent);
            _blindViews.Add(currentBlindViewable);
            currentBlindViewable.Spawned(blindSpawnerConfig[i]);   
        }
        
        if (Selector.Value != null)
            Selector.Dispose();
        Selector.Value = null;
        Selector.Value = new BlindSelector(_blindViews);
    }

    public void Dispose()
    {
        Selector.Dispose();
        _blindSortSpawner.BlindAdded -= OnBlindAdded;
    }
}