using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CombinationInstaller : MonoInstaller
{
    [SerializeField] private CombinationsConfig _combinationsConfig;
    public override void InstallBindings()
    {
        Container.Bind<CombinationsConfig>().FromInstance(_combinationsConfig);
        Container.Bind<CombinationContainer>().FromNew().AsSingle();
    }
}
