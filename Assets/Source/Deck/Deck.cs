using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Deck : IDisposable, IInitializable
{
    public List<Card> Cards = new List<Card>();
    public List<Card> GlobalCards = new List<Card>();

    private DeckHandler _deckHandler;
    private DeckConfig _config;
    private IDeckContainable _deckContainable;

    private Sequence _sequence;
    
    public Deck(DeckHandler handler, DeckConfig config, IDeckContainable deckContainable)
    {
        _deckHandler = handler;
        _config = config;
        _deckContainable = deckContainable;
        FillGlobalDeck();
        FillDeck();
    }

    public void FillGlobalDeck()
    {
        
        for (int i = 0; i < _config.DeckDefaultCapacity; i++)
        {
            Add(new Card(_deckContainable.CardDatas[i]), true);
        }
    }
    
    public void FillDeck()
    {
        for (int i = 0; i < GlobalCards.Count; i++)
        {
            Debug.Log(GlobalCards[i]);
            Add(GlobalCards[i]);
        }
    }

    public void Add(Card card, bool isGlobal = false)
    {
        List<Card> cards = isGlobal ? ref GlobalCards : ref Cards;
        _deckHandler.Add(ref cards, card);
    }
    
    public void PutAway(Card card, bool isGlobal = false)
    {
        List<Card> cards = isGlobal ?  ref GlobalCards : ref Cards;
        _deckHandler.PutAway(ref cards, card);
    }
    
    

    public Card Take(Card card, bool isGlobal = false)
    {
        List<Card> cards = isGlobal ? Cards : GlobalCards;
        if (_deckHandler.TryTake(cards, card, out card))
            return card;
        return null;
    }

    public Card Take(bool isGlobal = false)
    {
        List<Card> cards = isGlobal ? Cards : GlobalCards;
        Card card = cards[Random.Range(0, cards.Count - 1)];
        if (_deckHandler.TryTake(cards, card, out Card outcard))
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