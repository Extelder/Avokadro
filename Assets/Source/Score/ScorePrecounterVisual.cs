using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class ScorePrecounterVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Hand _hand;
    private CompositeDisposable _disposable = new CompositeDisposable();

    [Inject]
    public void Construct(Hand hand)
    {
        _hand = hand;
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
        int cardValue = 0;
        for (int i = 0; i < cardVisuals.Count; i++)
        {
            cardValue += cardVisuals[i].Card.Rank.GetCardValue();
        }
        _text.text = cardValue.ToString();
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _hand.CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
    }
}