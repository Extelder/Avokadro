using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TarrotCardInstaller : MonoInstaller
{
    [SerializeField] private GameObject _tarotViewPrefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        TarotCardView tarotCardView = Container.InstantiatePrefabForComponent<TarotCardView>(
            _tarotViewPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.Bind<ITarotCardViewable>().FromInstance(tarotCardView);
        Container.BindInterfacesAndSelfTo<TarotCard>().FromNew().AsSingle();
    }
}
