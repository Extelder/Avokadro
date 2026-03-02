using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandInstaller : MonoInstaller
{
    [SerializeField] private HandConfig _handConfig;
    [SerializeField] private GameObject _handPrefab;
    [SerializeField] private Transform _handSpawnParent;
    
    public override void InstallBindings()
    {
        Container.Bind<HandConfig>().FromInstance(_handConfig);
        HandView handView = Container.InstantiatePrefabForComponent<HandView>(
            _handPrefab,
            _handSpawnParent);
        Container.BindInterfacesAndSelfTo<HandView>().FromInstance(handView);
        Container.BindInterfacesAndSelfTo<Hand>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<HandHandler>().FromNew().AsSingle();
    }
}
