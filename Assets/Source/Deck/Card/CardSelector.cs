using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class CardSelector
{

    private CompositeDisposable _disposable = new CompositeDisposable();

    private List<CardVisual> _selectedCardVisuals = new List<CardVisual>();

    public event Action<List<CardVisual>> SelectedCardsChanged;

    public CardSelector(List<CardVisual> cardsToChoose, DiContainer container, ref List<CardVisual> selectedCards)
    {
        container.Inject(this);
        foreach (var card in cardsToChoose)
        {
            Debug.Log("START FOREACH");
            card.CardImage.OnPointerClickAsObservable().Subscribe(_ =>
            {
                OnCardClicked(card);
                Debug.Log("ddddYAICA");
            }).AddTo(_disposable);
        }
    }

    public void OnCardClicked(CardVisual cardVisual)
    {
        if (_selectedCardVisuals.Contains(cardVisual))
        {
            _selectedCardVisuals.Remove(cardVisual);
            SelectedCardsChanged?.Invoke(_selectedCardVisuals);
            return;
        }

        _selectedCardVisuals.Add(cardVisual);
        SelectedCardsChanged?.Invoke(_selectedCardVisuals);
    }

    ~CardSelector()
    {
        _disposable.Clear();
    }
}