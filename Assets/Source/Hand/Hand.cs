using System;
using Zenject;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;


public class Hand
{
    public ReactiveProperty<CardSelector> CardSelector { get; private set; } = new ReactiveProperty<CardSelector>();
    public List<Card> Cards { get; private set; } = new List<Card>();
    private DiContainer _container;


    private CombinationContainer _combinationContainer;
    private Tween _tween;

    public event Action<CardVisual[]> PlayHand;
    public event Action<CardVisual[]> CardsPlayed;

    private CardVisual[] _currentSelectedCards;
    
    public Hand(DiContainer container, CombinationContainer combinationContainer)
    {
        _container = container;
        _combinationContainer = combinationContainer;
    }

    public void SpawnSelector(List<CardVisual> cardVisuals)
    {
        if (CardSelector.Value != null)
            CardSelector.Value.Dispose();

        CardSelector.Value = null;
        CardSelector.Value = new CardSelector(cardVisuals, _container);
        for (int i = 0; i < cardVisuals.Count; i++)
        {
            Debug.Log(cardVisuals[i].Card);
        }

        CardSelector.Value.SelectedCardsChanged += OnSelectedCardsChanged;
    }

    public void NextHand(CardVisual[] cardVisuals)
    {
        CardsPlayed?.Invoke(cardVisuals);
    }

    ~Hand()
    {
        CardSelector.Value.SelectedCardsChanged -= OnSelectedCardsChanged;
        _tween.Kill();
    }

    private void OnSelectedCardsChanged(List<CardVisual> cards)
    {
        Debug.Log("SELECTED CARDSA CHANGED");
        _currentSelectedCards = cards.ToArray();
    }

    public void Play()
    {
        PlayHand?.Invoke(_currentSelectedCards);
    }
}