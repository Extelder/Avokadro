using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ScorePrecounterVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Hand _hand;

    [Inject]
    public void Construct(Hand hand)
    {
        _hand = hand;
    }

    private void Start()
    {
        _hand.CardSelector.SelectedCardsChanged += OnSelectedCardsChanged;
    }

    private void OnSelectedCardsChanged(List<CardVisual> cardVisuals)
    {
        int cardValue = 0;
        for (int i = 0; i < cardVisuals.Count; i++)
        {
            cardValue += cardVisuals[i].Card.Rank.GetCardValue();
        }
        _text.text = cardValue.ToString();
    }

    private void OnDisable()
    {
        _hand.CardSelector.SelectedCardsChanged -= OnSelectedCardsChanged;
    }
}