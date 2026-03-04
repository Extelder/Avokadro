using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class HandDiscardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _discardText;
    [SerializeField] private TextMeshProUGUI _handText;

    private Round _round;

    [Inject]
    public void Construct(Round round)
    {
        _round = round;
    }

    private void Start()
    {
        _round.DiscradsValueChanged += OnDiscradsValueChanged;
        _round.HandsValueChanged += OnHandsValueChanged;
        OnHandsValueChanged(_round.Hands);
        OnDiscradsValueChanged(_round.Discards);
    }

    private void OnDisable()
    {
        _round.DiscradsValueChanged -= OnDiscradsValueChanged;
        _round.HandsValueChanged -= OnHandsValueChanged;
    }

    private void OnHandsValueChanged(int value)
    {
        _handText.text = value.ToString();
    }

    private void OnDiscradsValueChanged(int value)
    {
        _discardText.text = value.ToString();
    }
}