using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoundInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Round>().FromNew().AsSingle();
    }
}