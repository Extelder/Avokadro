using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlindSortInstaller : MonoInstaller
{
    [SerializeField] private GameObject _blindSortPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BlindSortSpawner>().FromNew().AsSingle();
        BlindSortSpawnerView blindView = Container.InstantiatePrefabForComponent<BlindSortSpawnerView>(
            _blindSortPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.BindInterfacesAndSelfTo<IBlindSortSpawnerViewable>().FromInstance(blindView);
    }
}
