using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BlindSelector
{
    public event Action<IBlindViewable> BlindSelected; 
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public BlindSelector(List<IBlindViewable> blindViews)
    {
        foreach (var blindView in blindViews)
        {
            blindView.PlayButton.OnPointerClickAsObservable().Subscribe(_ =>
            {
                OnBlindSelected(blindView);
            }).AddTo(_disposable);
        }
    }

    private void OnBlindSelected(IBlindViewable blindViewable)
    {
        Debug.Log("BLIND SELECTED");
        BlindSelected?.Invoke(blindViewable);
    }
}
