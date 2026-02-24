using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    public Card Card { get; private set; }
    public Image CardImage { get; private set; }

    public void Init(Card card)
    {
        CardImage.sprite = card.CardData.Icon;
    }
}