using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    public Card(CardData cardData)
    {
        Suit = cardData.Suit;
        Rank = cardData.Rank;
    }
}