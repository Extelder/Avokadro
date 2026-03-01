using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardVisual : MonoBehaviour
{
    public Card Card { get; private set; }
    [field: SerializeField] public Image CardImage { get; private set; }
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TextMeshProUGUI _text;

    public virtual void Init(Card card)
    {
        Card = card;
        CardImage.sprite = card.CardData.Icon;
    }

    public void ShowScore(int score)
    {
        _textPanel.SetActive(true);
        _text.text = "+" + score;
    }
}