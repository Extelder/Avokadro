using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeckHandler
{
    public abstract void Add(List<Card> cards, Card card);

    public abstract void PutAway(List<Card> cards, Card card);

    public abstract bool TryTake(List<Card> cards, Card needCard, out Card chosenCard);
}
