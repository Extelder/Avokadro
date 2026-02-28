using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardInstaller : MonoInstaller
{
    [SerializeField] private CardVisual _cardVisualPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<CardVisual>().FromInstance(_cardVisualPrefab);
    }
}
