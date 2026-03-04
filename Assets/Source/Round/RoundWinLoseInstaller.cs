using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoundWinLoseInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<RoundWinLose>().FromNew().AsSingle();
    }
}