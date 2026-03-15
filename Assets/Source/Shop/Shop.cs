using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : IInitializable, IDisposable
{
    private Deck _deck;

    public event Action ShopActivated;
    public event Action ShopDeactivated;

    public Shop(Deck deck)
    {
        _deck = deck;
    }

    public void Initialize()
    {
        RoundWinLose.Winned += OnRoundWinned;
    }

    private void OnRoundWinned()
    {
        ShopActivated?.Invoke();
    }

    public void CloseShop()
    {
        ShopDeactivated?.Invoke();
    }

    public void Dispose()
    {
        RoundWinLose.Winned -= OnRoundWinned;
    }
}