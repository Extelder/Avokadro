using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Deck
{
    protected DeckHandler deckHandler;
    public List<Card> Cards = new List<Card>();

    public Deck(DeckHandler handler)
    {
        deckHandler = handler;
    }

    public void Add(Card card)
    {
        deckHandler.Add(Cards, card);
    }

    public void PutAway(Card card)
    {
        deckHandler.PutAway(Cards, card);
    }

    public Card Take(Card card)
    {
        if (deckHandler.TryTake(Cards, card, out card))
            return card;
        return null;
    }
}