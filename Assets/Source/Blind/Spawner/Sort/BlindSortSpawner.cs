using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BlindSortSpawner : IInitializable
{
    public event Action<List<BlindConfig>> BlindAdded;

    private IBlindSortSpawnerViewable _blindSortSpawner;
    private List<BlindConfig> _blindConfigsToSpawn = new List<BlindConfig>();

    public BlindSortSpawner(IBlindSortSpawnerViewable blindSortSpawnerViewable)
    {
        _blindSortSpawner = blindSortSpawnerViewable;
    }

    public void AddToSpawn()
    {
        _blindConfigsToSpawn.Clear();
        _blindConfigsToSpawn.Add(_blindSortSpawner.BlindConfigsKeeper.SmallBlind);
        _blindConfigsToSpawn.Add(_blindSortSpawner.BlindConfigsKeeper.BigBlind);
        _blindConfigsToSpawn.Add(
            _blindSortSpawner.BlindConfigsKeeper.SpecialBlinds[
                Random.Range(0, _blindSortSpawner.BlindConfigsKeeper.SpecialBlinds.Length - 1)]);
        BlindAdded?.Invoke(_blindConfigsToSpawn);
    }

    public void Initialize()
    {
        AddToSpawn();
    }
}