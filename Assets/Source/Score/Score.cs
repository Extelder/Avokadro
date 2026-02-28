using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Score : IInitializable
{
    public int CurrentValue { get; private set; }
    private ScoreConfig _config;
    private IScoreViewable _scoreViewable;
    private Hand _hand;
    private CombinationContainer _combinationContainer;
    
    public Score(ScoreConfig config, IScoreViewable scoreViewable, Hand hand, CombinationContainer combinationContainer)
    {
        _config = config;
        _scoreViewable = scoreViewable;
        _hand = hand;
        _combinationContainer = combinationContainer;
        CurrentValue = _config.StartValue;
        _hand.PlayHand += OnHandPlayed;
        _scoreViewable.ChangeVisual(CurrentValue);
    }

    private void OnHandPlayed(CardVisual[] cardVisuals)
    {
        Combination combination = cardVisuals.ToList().GetBestCombination(_combinationContainer.CombinationsConfig);
        for (int i = 0; i < cardVisuals.Length; i++)
        {
            Add(cardVisuals[i].Card.Rank.GetCardValue() * combination.Multiplier);
        }
    }

    public void Add(int addValue)
    {
        if (CurrentValue + addValue > _config.MinValue)
        {
            CurrentValue += addValue;
            _scoreViewable.ChangeVisual(CurrentValue);
            return;
        }
        
        CurrentValue = _config.StartValue;
        _scoreViewable.ChangeVisual(CurrentValue);
    }

    public void Initialize()
    {
    }
}
