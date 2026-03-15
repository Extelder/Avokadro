using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class WalletUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI moneyText;
    [Inject] protected Wallet wallet;

    private void OnEnable()
    {
        this.wallet.ValueChanged += OnValueChanged;
        OnValueChanged(wallet.Value);
    }

    private void OnValueChanged(int value)
    {
        moneyText.text = value.ToString();
    }

    private void OnDisable()
    {
        this.wallet.ValueChanged -= OnValueChanged;
    }
}