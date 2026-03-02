using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class CombinationMultiplayerVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private CombinationContainer _combinationContainer;
    private Hand _hand;
    private CompositeDisposable _disposable = new CompositeDisposable();

    [Inject]
    public void Construct(Hand hand, CombinationContainer combinationContainer)
    {
        _hand = hand;
        _combinationContainer = combinationContainer;
    }

    private void Start()
    {
        _hand.CardSelector.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }
            _text.text = "0";
            _hand.CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
            _.SelectedCardsChanged += OnSelectedCardsChanged;
        }).AddTo(_disposable);
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
        _hand.CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
    }
}