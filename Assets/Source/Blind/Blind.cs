using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Blind : IDisposable
{
    public event Action BlindSetUped;

    private BlindSelector _blindSelector;
    private CompositeDisposable _disposable = new CompositeDisposable();

    public Blind(BlindSpawner blindSpawner)
    {
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
        BlindSetUped?.Invoke();
    }


    public void Dispose()
    {
        _disposable.Clear();
    }
}
