using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public int Value { get; protected set; }

    protected readonly int minValue = 0;
    protected readonly int maxValue = 100;

    public event Action<int> ValueChanged;

    public Wallet(int minValue, int maxValue, int startValue)
    {
        if (minValue > maxValue)
        {
            Debug.LogError(this + "Wallet minValue > maxValue");
            Debug.Break();
            return;
        }

        if (maxValue < minValue)
        {
            Debug.LogError(this + "Wallet maxValue < minValue");
            Debug.Break();
            return;    
        }

        this.minValue = minValue;
        this.maxValue = maxValue;


        Add(startValue);
    }

    public bool TrySpend(uint value)
    {
        if (Value - value < minValue)
        {
            return false;
        }

        Value -= (int) value;
        ValueChanged?.Invoke(Value);
        return true;
    }

    public void Add(int value)
    {
        if (Value + value > maxValue)
        {
            Value = maxValue;
            ValueChanged?.Invoke(Value);
            return;
        }

        Value += value;
        ValueChanged?.Invoke(Value);
    }
}