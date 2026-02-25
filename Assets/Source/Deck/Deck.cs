using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Deck : IDisposable, IInitializable
{
    public List<Card> Cards = new List<Card>();

    private DeckHandler _deckHandler;
    private DeckConfig _config;
    private IDeckContainable _deckContainable;

    public Deck(DeckHandler handler, DeckConfig config, IDeckContainable deckContainable)
    {
        _deckHandler = handler;
        _config = config;
        _deckContainable = deckContainable;
        FillDeck();
    }

    public void FillDeck()
    {
        for (int i = 0; i < _config.DeckDefaultCapacity; i++)
        {
            Add(new Card(_deckContainable.CardDatas[i]));
        }
    }

    public void Add(Card card)
    {
        _deckHandler.Add(ref Cards, card);
    }

    public void PutAway(Card card)
    {
        _deckHandler.PutAway(ref Cards, card);
    }

    public Card Take(Card card)
    {
        if (_deckHandler.TryTake(Cards, card, out card))
            return card;
        return null;
    }

    public Card Take()
    {
        Card card = Cards[Random.Range(0, Cards.Count - 1)];
        if (_deckHandler.TryTake(Cards, card, out Card outcard))
            return outcard;
        return null;
    }
    
    public void Initialize()
    {
    }

    public void Dispose()
    {
    }
}