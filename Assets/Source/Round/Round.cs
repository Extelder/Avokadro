using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Round : IDisposable
{
    public int Hands { get; private set; }
    public int Discards { get; private set; }
    public int PointsToWin { get; set; }
    private CompositeDisposable _disposable = new CompositeDisposable();
    private BlindSelector _blindSelector;
    public event Action<int> HandsValueChanged;
    public event Action<int> DiscradsValueChanged;

    private Round(PlayerProgression progression, BlindSpawner blindSpawner)
    {
        Hands = progression.Hands.Value;
        Discards = progression.Discards.Value;
        _blindSelector = blindSpawner.Selector.Value;
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
        PointsToWin = blindViewable.BlindConfig.GoalScore;
    }

    public bool TrySpentHand()
    {
        if (Hands - 1 >= 0)
        {
            Hands--;
            HandsValueChanged?.Invoke(Hands);
            return true;
        }

        return false;
    }

    public bool TrySpentDiscard()
    {
        if (Discards - 1 >= 0)
        {
            Discards--;
            DiscradsValueChanged?.Invoke(Discards);
            return true;
        }

        return false;
    }

    public void Dispose()
    {
        _blindSelector.BlindSelected -= OnBlindSelected;
        _disposable.Clear();
    }
}