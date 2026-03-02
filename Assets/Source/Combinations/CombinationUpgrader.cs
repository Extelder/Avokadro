using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = System.Random;

public class CombinationUpgrader : IDisposable
{
    public event Action<int> CombinationUpgrade;
    
    private CompositeDisposable _disposable = new CompositeDisposable();

    public CombinationUpgrader()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CombinationUpgrade?.Invoke(0);
            }
        }).AddTo(_disposable);
    }
    
    public void Dispose()
    {
        _disposable.Clear();
    }
}
