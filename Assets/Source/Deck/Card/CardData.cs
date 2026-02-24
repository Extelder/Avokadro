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
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    J,
    Q,
    K,
    A
}


[CreateAssetMenu(menuName = "Deck/Card")]
public class CardData : ScriptableObject
{
    [field: SerializeField] public Suit Suit { get; private set; }
    [field: SerializeField] public Rank Rank { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}