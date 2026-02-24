using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandHandler : IInitializable
{
    private HandConfig _config;
    private Deck _deck;
    private Hand _hand;
    private IHandContainable _handContainable;

    public HandHandler(Hand hand, IHandContainable handContainable, HandConfig config, Deck deck)
    {
        Debug.Log("faw");
        _handContainable = handContainable;
        _hand = hand;
        _config = config;
        _deck = deck;
        FillHand();
    }

    public void FillHand()
    {
        Debug.Log("FILL HAND");
        int cardsToSpawnCount = _config.CardsCapacity - _hand.Cards.Count;
        for (int i = 0; i < cardsToSpawnCount - 1; i++)
        {
            SpawnCard();
        }
    }

    private void SpawnCard()
    {
        _hand.Cards.Add(_deck.Take());
        Debug.Log("HAND ADDED");
    }

    public void Initialize()
    {
        FillHand();
    }
}