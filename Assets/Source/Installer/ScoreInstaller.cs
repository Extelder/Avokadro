using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    [SerializeField] private ScoreConfig _scoreConfig;
    [SerializeField] private GameObject _scoreViewPrefab;
    [SerializeField] private Transform _scoreSpawnParent;

    public override void InstallBindings()
    {
        Container.Bind<ScoreConfig>().FromInstance(_scoreConfig);
        ScoreView scoreView = Container.InstantiatePrefabForComponent<ScoreView>(
            _scoreViewPrefab,
            _scoreSpawnParent);
        Container.Bind<IScoreViewable>().FromInstance(scoreView);
        Container.BindInterfacesAndSelfTo<Score>().FromNew().AsSingle();
    }
}
