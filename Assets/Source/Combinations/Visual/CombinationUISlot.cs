using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class CombinationUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _value;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public void Init(Combination combination)
    {
        _name.text = combination.Name;
        UpdateVisual(combination);
        combination.CurrentMultiplier.Subscribe(_ => { UpdateVisual(combination); }).AddTo(_disposable);
    }

    public void UpdateVisual(Combination combination)
    {
        _value.text = "x" + combination.CurrentMultiplier.Value.ToString();
    }

    private void OnDisable()
    {
        _disposable?.Clear();
    }
}