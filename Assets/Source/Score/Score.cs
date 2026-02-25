using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Score : IInitializable
{
    public int CurrentValue { get; private set; }
    private ScoreConfig _config;
    private IScoreViewable _scoreViewable;
    
    public Score(ScoreConfig config, IScoreViewable scoreViewable)
    {
        _config = config;
        _scoreViewable = scoreViewable;
        CurrentValue = _config.StartValue;
        _scoreViewable.ChangeVisual(CurrentValue);
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
