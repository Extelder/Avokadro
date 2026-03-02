using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class HandCombinationVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _combinationText;

    private Hand _hand;
    private CombinationContainer _combinationContainer;
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
            _combinationText.text = "Null";
            _hand.CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
            _.SelectedCardsChanged += OnSelectedCardsChanged;   
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _hand.CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
    }

    private void OnSelectedCardsChanged(List<CardVisual> cards)
    {
        Debug.Log("CARDS CHANGED");
        if (cards.Count > 0)
            _combinationText.text = cards.GetBestCombination(_combinationContainer.CombinationsConfig).Name;
    }
}