using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Blind : IDisposable
{
    private BlindSelector _blindSelector;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private Round _round;
    
    public Blind(BlindSpawner blindSpawner, Round round)
    {
        _round = round;
        blindSpawner.Selector.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }
            _blindSelector = _;
            _blindSelector.BlindSelected += OnBlindSelected;
        }).AddTo(_disposable);
    }

    private void OnBlindSelected(IBlindViewable blindViewable)
    {
        _round.PointsToWin = blindViewable.BlindConfig.GoalScore;
    }
    
    public void Dispose()
    {
        _disposable.Clear();
    }
}
