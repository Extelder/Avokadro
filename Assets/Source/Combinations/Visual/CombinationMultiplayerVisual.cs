using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CombinationMultiplayerVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private CombinationContainer _combinationContainer;
    private Hand _hand;

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

    private void OnSelectedCardsChanged(List<CardVisual> cardVisuals)
    {
        int combinationMultiplier = 0;
        if (cardVisuals.Count < 0)
            return;
        Combination combination = cardVisuals.GetBestCombination(_combinationContainer.CombinationsConfig);
        if (combination == null)
        {
            _text.text = "0";
            return;
        }
        combinationMultiplier = combination.Multiplier;
        _text.text = combinationMultiplier.ToString();
    }

    private void OnDisable()
    {
        _hand.CardSelector.SelectedCardsChanged -= OnSelectedCardsChanged;
    }
}