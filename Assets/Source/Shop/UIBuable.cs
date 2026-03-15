using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIBuable : Buyable
{
    [SerializeField] private Button _button;
    [SerializeField] private uint _cost;


    [Inject] private Wallet _wallet;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => { OnBuyButtonClicked(); });
    }

    private void OnBuyButtonClicked()
    {
        TryBuy();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public override bool TryBuy()
    {
        if (_wallet.TrySpend(_cost))
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}