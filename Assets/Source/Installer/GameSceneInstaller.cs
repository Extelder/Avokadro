using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private DeckConfig _deckConfig;
    [SerializeField] private HandConfig _handConfig;
    [SerializeField] private ScoreConfig _scoreConfig;
    [SerializeField] private CombinationsConfig _combinationsConfig;
    [SerializeField] private GameObject _deckPrefab;
    [SerializeField] private GameObject _handPrefab;
    [SerializeField] private GameObject _tarotViewPrefab;
    [SerializeField] private GameObject _scoreViewPrefab;

    [SerializeField] private CardVisual _cardVisualPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _handSpawnParent;
    [SerializeField] private Transform _scoreSpawnParent;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<DeckConfig>().FromInstance(_deckConfig);
        Container.Bind<HandConfig>().FromInstance(_handConfig);
        Container.Bind<ScoreConfig>().FromInstance(_scoreConfig);
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
            _handSpawnParent);
        Container.Bind<IHandContainable>().FromInstance(handView);

        TarotCardView tarotCardView = Container.InstantiatePrefabForComponent<TarotCardView>(
            _tarotViewPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.Bind<ITarotCardViewable>().FromInstance(tarotCardView);
        
        ScoreView scoreView = Container.InstantiatePrefabForComponent<ScoreView>(
            _scoreViewPrefab,
            _scoreSpawnParent);
        Container.Bind<IScoreViewable>().FromInstance(scoreView);

        Container.Bind<Camera>().FromInstance(_camera);

        Container.BindInterfacesAndSelfTo<TarotCard>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Score>().FromNew().AsSingle();
        Container.Bind<DeckHandler>().To<DefaultDeckHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Deck>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<Hand>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<HandHandler>().FromNew().AsSingle();
    }
}