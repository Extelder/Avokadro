using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class DefaultDeckHandler : DeckHandler, IInitializable
{
    public override void Add(List<Card> cards, Card card)
    {
        cards.Add(card);
    }

    public override void PutAway(List<Card> cards, Card card)
    {
        cards.Remove(card);
    }

    public override bool TryTake(List<Card> cards, Card needCard, out Card chosenCard)
    {
        Card foundCard = cards.FirstOrDefault(checkCard => 
            checkCard.Suit == needCard.Suit && checkCard.Rank == needCard.Rank);
        chosenCard = foundCard;
        return foundCard != null;
    }

    public void Initialize()
    {
    }
}