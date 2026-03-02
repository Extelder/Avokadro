using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayableHandInstaller : MonoInstaller
{
    [SerializeField] private PlayableHandConfig _playableHandConfig;
    public override void InstallBindings()
    {
        Container.Bind<PlayableHandConfig>().FromInstance(_playableHandConfig).AsSingle();
        Container.BindInterfacesAndSelfTo<PlayableHand>().FromNew().AsSingle();
    }
}
