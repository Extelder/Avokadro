using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;


public class Hand
{
    private CardSelector _cardSelector;
    public List<Card> Cards { get; private set; } = new List<Card>();
    private DiContainer _container;

    private List<CardVisual> _selectedCards = new List<CardVisual>();

    public Hand(DiContainer container)
    {
        Debug.Log("JHAF");
        _container = container;
    }

    public void SpawnSelector(List<CardVisual> cardVisuals)
    {
        _cardSelector = new CardSelector(cardVisuals, _container, ref _selectedCards);
        _cardSelector.SelectedCardsChanged += OnSelectedCardsChanged;
    }

    ~Hand()
    {
        _cardSelector.SelectedCardsChanged -= OnSelectedCardsChanged;
    }

    private void OnSelectedCardsChanged(List<CardVisual> cards)
    {
        //Combination combination = cards.GetBestCombination()
    }

    public void Play()
    {
    }
}