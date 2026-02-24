using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;


public class Hand 
{
    private CardSelector _cardSelector;
    public List<Card> Cards { get; private set; } = new List<Card>();

    public Hand(DiContainer container)
    {
        Debug.Log("JHAF");
        _cardSelector = new CardSelector(Cards, container);
    }

    public void Play()
    {
    }
}