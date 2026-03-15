using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BlindSelector
{
    public event Action ButtonCliked;
    public event Action<IBlindViewable> BlindSelected; 
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public BlindSelector(List<IBlindViewable> blindViews)
    {
        foreach (var blindView in blindViews)
        {
            IBlindViewable blindViewable = blindView;
            blindViewable.PlayButton.OnPointerClickAsObservable().Subscribe(_ =>
            {
                OnBlindSelected(blindViewable);
            }).AddTo(_disposable);
        }
    }

    private void OnBlindSelected(IBlindViewable blindViewable)
    {
        ButtonCliked?.Invoke();
        BlindSelected?.Invoke(blindViewable);
    }
}
