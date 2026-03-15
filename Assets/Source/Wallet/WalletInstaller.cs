using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WalletInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Wallet>().FromNew().AsSingle().WithArguments(0, 100000000, 2);
    }
}