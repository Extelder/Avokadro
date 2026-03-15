using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ShopHandler : IInitializable, IDisposable
{
    private List<Buyable> _currentBuyables = new List<Buyable>();

    private Shop _shop;

    private ShopConfig _config;

    private IShopSpawnInput _shopSpawnInput;

    private DiContainer _container;
    
    public ShopHandler(Shop shop, ShopConfig config, IShopSpawnInput shopSpawnInput, DiContainer container)
    {
        _container = container;
        _shopSpawnInput = shopSpawnInput;
        _shop = shop;
        _config = config;
    }

    public void Initialize()
    {
        _shop.ShopActivated += OnShopActivated;
        _shop.ShopDeactivated += OnShopDeactivated;
    }

    private void OnShopDeactivated()
    {
        if (!_currentBuyables.Any())
            return;
        for (int i = 0; i < _currentBuyables.Count; i++)
        {
            if (_currentBuyables[i] == null)
                continue;

            MonoBehaviour.Destroy(_currentBuyables[i].gameObject);
        }

        _currentBuyables.Clear();
    }

    private void OnShopActivated()
    {
        for (int i = 0; i < _config.NumberOfBuyables; i++)
        {
            _currentBuyables.Add(MonoBehaviour.Instantiate(_config.Buyables[Random.Range(0, _config.Buyables.Count)],
                _shopSpawnInput.SpawnPoint));
            _container.Inject(_currentBuyables[i]);
        }
    }

    public void Dispose()
    {
        _shop.ShopActivated -= OnShopActivated;
        _shop.ShopDeactivated -= OnShopDeactivated;
    }
}