using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopUI : MonoBehaviour, IShopSpawnInput
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Button _offShopButton;

    [field: SerializeField] public Transform SpawnPoint { get; set; }


    private Shop _shop;

    [Inject]
    public void Construct(Shop shop)
    {
        _shop = shop;
    }

    private void Start()
    {
        _offShopButton.onClick.AddListener(() => { _shop.CloseShop(); });
        _shop.ShopActivated += OnShopActivated;
        _shop.ShopDeactivated += OnShopDeactivated;
    }

    private void OnShopDeactivated()
    {
        _shopPanel.SetActive(false);
    }

    private void OnShopActivated()
    {
        _shopPanel.SetActive(true);
    }

    private void OnDisable()
    {
        _offShopButton.onClick.RemoveAllListeners();
        _shop.ShopActivated -= OnShopActivated;
        _shop.ShopDeactivated -= OnShopDeactivated;
    }
}