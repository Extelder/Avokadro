using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;


public class Hand 
{
    private CardSelector _cardSelector;
    public List<Card> Cards { get; private set; } = new List<Card>();
    private DiContainer _container;

    public Hand(DiContainer container)
    {
        Debug.Log("JHAF");
        _container = container;
    }

    public void SpawnSelector(List<CardVisual> cardVisuals)
    {
        _cardSelector = new CardSelector(cardVisuals, _container);
    }
    
    public void Play()
    {
    }
}