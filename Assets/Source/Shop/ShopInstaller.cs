using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private ShopConfig _shopConfig;
    [SerializeField] private ShopUI _shopUi;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Shop>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<ShopUI>().FromInstance(_shopUi).AsSingle();
        Container.Bind<ShopConfig>().FromInstance(_shopConfig).AsSingle();
        Container.BindInterfacesAndSelfTo<ShopHandler>().FromNew().AsSingle();
    }
}