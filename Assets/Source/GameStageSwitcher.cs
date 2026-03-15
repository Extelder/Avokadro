using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

[Serializable]
public struct Stage
{
    [field: SerializeField] public GameObject StageObject { get; set; }
}

public class GameStageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _previoseStage;
    [SerializeField] private List<Stage> _stages = new List<Stage>();
    private CompositeDisposable _disposable = new CompositeDisposable();
    private Shop _shop;
    private int _index;
    private BlindSelector _blindSelector;

    [Inject]
    public void Construct(BlindSpawner blindSpawner, Shop shop)
    {
        _blindSelector = blindSpawner.Selector.Value;
        _shop = shop;
        _shop.ShopDeactivated += OnStageSwitching;
        RoundWinLose.Winned += OnStageSwitching;
        blindSpawner.Selector.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }
            _blindSelector = _;
            _blindSelector.ButtonCliked += OnStageSwitching;
        }).AddTo(_disposable);
    }

    private void OnStageSwitching()
    {
        _index++;
        if (_index > _stages.Count - 1)
            _index = 0;
        _previoseStage.SetActive(false);
        _previoseStage = _stages[_index].StageObject;
        _previoseStage.SetActive(true);
    }


    private void OnDisable()
    {
        _blindSelector.ButtonCliked -= OnStageSwitching;
        _shop.ShopDeactivated -= OnStageSwitching;
        RoundWinLose.Winned -= OnStageSwitching;
    }
}