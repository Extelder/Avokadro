using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class HandCombinationVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _combinationText;

    private Hand _hand;
    private CombinationContainer _combinationContainer;

    [Inject]
    public void Construct(Hand hand, CombinationContainer combinationContainer)
    {
        _hand = hand;
        _combinationContainer = combinationContainer;
    }

    private void Start()
    {
        _hand.CardSelector.SelectedCardsChanged += OnSelectedCardsChanged;
    }

    private void OnDisable()
    {
        _hand.CardSelector.SelectedCardsChanged -= OnSelectedCardsChanged;
    }

    private void OnSelectedCardsChanged(List<CardVisual> cards)
    {
        if (cards.Count > 0)
            _combinationText.text = cards.GetBestCombination(_combinationContainer.CombinationsConfig).Name;
    }
}