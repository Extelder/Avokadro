using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlindInstaller : MonoInstaller
{
    [SerializeField] private BlindSpawnerConfig _blindSpawnerConfig;
    [SerializeField] private BlindConfigsKeeper blindConfigsKeeper;
    [SerializeField] private GameObject _blindSpawnerPrefab;
    [SerializeField] private GameObject _blindPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;

    public override void InstallBindings()
    {
        Container.Bind<BlindSpawnerConfig>().FromInstance(_blindSpawnerConfig).AsSingle();
        Container.Bind<BlindConfigsKeeper>().FromInstance(blindConfigsKeeper).AsSingle();
        BlindSpawnerView blindSpawnerView = Container.InstantiatePrefabForComponent<BlindSpawnerView>(
            _blindSpawnerPrefab,
            _parent);
        Container.BindInterfacesAndSelfTo<BlindSpawnerView>().FromInstance(blindSpawnerView);
        
        BlindView blindView = Container.InstantiatePrefabForComponent<BlindView>(
            _blindPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.BindInterfacesAndSelfTo<BlindView>().FromInstance(blindView);
        Container.Bind<Blind>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<BlindSpawner>().FromNew().AsSingle();
        Container.Bind<BlindHandler>().FromNew().AsSingle();
    }
}
