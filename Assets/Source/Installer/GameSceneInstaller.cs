using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private DeckConfig _deckConfig;
    [SerializeField] private HandConfig _handConfig;
    [SerializeField] private CombinationsConfig _combinationsConfig;
    [SerializeField] private GameObject _deckPrefab;
    [SerializeField] private GameObject _handPrefab;
    [SerializeField] private GameObject _tarotViewPrefab;

    [SerializeField] private CardVisual _cardVisualPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnParent;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DeckConfig>().FromInstance(_deckConfig);
        Container.Bind<HandConfig>().FromInstance(_handConfig);
        Container.Bind<CombinationsConfig>().FromInstance(_combinationsConfig);
        Container.Bind<CombinationContainer>().FromNew().AsSingle();

        Container.Bind<CardVisual>().FromInstance(_cardVisualPrefab);
        DeckView deckView = Container.InstantiatePrefabForComponent<DeckView>(
            _deckPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.Bind<IDeckContainable>().FromInstance(deckView);

        HandView handView = Container.InstantiatePrefabForComponent<HandView>(
            _handPrefab,
            _spawnParent);
        Container.Bind<IHandContainable>().FromInstance(handView);

        TarotCardView tarotCardView = Container.InstantiatePrefabForComponent<TarotCardView>(
            _tarotViewPrefab,
            _spawnParent);
        Container.Bind<ITarotCardViewable>().FromInstance(tarotCardView);

        Container.Bind<Camera>().FromInstance(_camera);

        Container.BindInterfacesAndSelfTo<TarotCard>().FromNew().AsSingle();
        Container.Bind<DeckHandler>().To<DefaultDeckHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Deck>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Hand>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<HandHandler>().FromNew().AsSingle();
    }
}