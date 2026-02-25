using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;


public class Hand
{
    public CardSelector CardSelector { get; private set; }
    public List<Card> Cards { get; private set; } = new List<Card>();
    private DiContainer _container;

    private List<CardVisual> _selectedCards = new List<CardVisual>();

    private CombinationContainer _combinationContainer;

    public Hand(DiContainer container, CombinationContainer combinationContainer)
    {
        _container = container;
        _combinationContainer = combinationContainer;
    }

    public void SpawnSelector(List<CardVisual> cardVisuals)
    {
        CardSelector = new CardSelector(cardVisuals, _container, ref _selectedCards);
        for (int i = 0; i < cardVisuals.Count; i++)
        {
            Debug.Log(cardVisuals[i].Card);
        }

        CardSelector.SelectedCardsChanged += OnSelectedCardsChanged;
    }

    ~Hand()
    {
        CardSelector.SelectedCardsChanged -= OnSelectedCardsChanged;
    }

    private void OnSelectedCardsChanged(List<CardVisual> cards)
    {
//        Debug.Log(cards.GetBestCombination(_combinationContainer.CombinationsConfig).Name);
        //Combination combination = cards.GetBestCombination()
    }

    public void Play()
    {
    }
}