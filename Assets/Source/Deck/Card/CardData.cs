using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public enum Rank
{
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    J = 10,
    Q = 10,
    K = 10,
    A = 11
}


[CreateAssetMenu(menuName = "Card/Deck")]
public class CardData : ScriptableObject
{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }
    public Sprite Icon { get; set; }
}