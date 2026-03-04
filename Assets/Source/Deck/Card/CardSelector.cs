using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class CardSelector : IDisposable
{
    private CompositeDisposable _disposable = new CompositeDisposable();

    private List<CardVisual> _selectedCardVisuals = new List<CardVisual>();

    public event Action<List<CardVisual>> SelectedCardsChanged;

    private int _cardsToPlayCapacity;
    private int _currentSelectedCards;

    public CardSelector(List<CardVisual> cardsToChoose, DiContainer container, PlayerProgression playerProgression)
    {
        _currentSelectedCards = 0;
        _cardsToPlayCapacity = playerProgression.CardsToPlayCapacity.Value;

        container.Inject(this);
        foreach (var card in cardsToChoose)
        {
            card.CardImage.OnPointerClickAsObservable().Subscribe(_ => { OnCardClicked(card); }).AddTo(_disposable);
        }
    }

    public void OnCardClicked(CardVisual cardVisual)
    {
        if (_selectedCardVisuals.Contains(cardVisual))
        {
            _currentSelectedCards--;
            cardVisual.transform.DOLocalMoveY(0, 0.2f);
            _selectedCardVisuals.Remove(cardVisual);
            SelectedCardsChanged?.Invoke(_selectedCardVisuals);
            return;
        }

        if (_currentSelectedCards >= _cardsToPlayCapacity)
            return;
        _currentSelectedCards++;
        cardVisual.transform.DOLocalMoveY(100f, 0.2f);
        _selectedCardVisuals.Add(cardVisual);
        SelectedCardsChanged?.Invoke(_selectedCardVisuals);
    }

    public void Dispose()
    {
        _disposable.Clear();
    }
}