using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DeckInstaller : MonoInstaller
{
    [SerializeField] private DeckConfig _deckConfig;
    [SerializeField] private GameObject _deckPrefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DeckConfig>().FromInstance(_deckConfig);
        DeckView deckView = Container.InstantiatePrefabForComponent<DeckView>(
            _deckPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.Bind<IDeckContainable>().FromInstance(deckView);
        Container.Bind<DeckHandler>().To<DefaultDeckHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Deck>().FromNew().AsSingle();
    }
}
