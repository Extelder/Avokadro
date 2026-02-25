using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardVisual : MonoBehaviour
{
    public Card Card { get; private set; }
    [field: SerializeField] public Image CardImage { get; private set; }

    public virtual void Init(Card card)
    {
        Card = card;
        CardImage.sprite = card.CardData.Icon;
    }
}