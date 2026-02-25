using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandHandler : IInitializable
{
    private List<CardVisual> _spawnedCardVisuals = new List<CardVisual>();
    
    private CardVisual _cardVisual;
    private HandConfig _config;
    private Deck _deck;
    private Hand _hand;
    private IHandContainable _handContainable;

    public HandHandler(Hand hand, IHandContainable handContainable, HandConfig config, Deck deck, CardVisual cardVisual)
    {
        _cardVisual = cardVisual;
        _handContainable = handContainable;
        _hand = hand;
        _config = config;
        _deck = deck;
    }

    public void FillHand()
    {
        int cardsToSpawnCount = _config.CardsCapacity - _hand.Cards.Count;
        for (int i = 0; i < cardsToSpawnCount; i++)
        {
            SpawnCard();
        }
        _hand.SpawnSelector(_spawnedCardVisuals);
    }

    private void SpawnCard()
    {
        Card card = _deck.Take();
        CardVisual cardVisual = MonoBehaviour.Instantiate(_cardVisual, _handContainable.DefaultSpawnParent);
        cardVisual.Init(card);
        _spawnedCardVisuals.Add(cardVisual);
        _hand.Cards.Add(card);
    }

    public void Initialize()
    {
        FillHand();
    }
}