using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<PlayerConfig>().FromInstance(_config).AsSingle();
        Container.Bind<PlayerProgression>().FromNew().AsSingle();
    }
}