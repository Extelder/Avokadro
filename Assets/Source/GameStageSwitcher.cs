using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

[Serializable]
public struct Stage
{
   [field: SerializeField] public int MainPanel { get; set; }
   [field: SerializeField] public int BlindPanel { get; set; }
}

public class GameStageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _stageObjects;
    [SerializeField] private GameObject _previoseStage;
    [SerializeField] private Stage _stage;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private BlindSelector _blindSelector;

    [Inject]
    public void Construct(BlindSpawner blindSpawner)
    {
        _blindSelector = blindSpawner.Selector.Value;
        blindSpawner.Selector.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }
            _blindSelector = _;
            _blindSelector.BlindSelected += OnBlindSelected;
        }).AddTo(_disposable);
    }

    private void OnBlindSelected(IBlindViewable blindViewable)
    {
        _previoseStage.SetActive(false);
        _previoseStage = _stageObjects[_stage.BlindPanel];
        _previoseStage.SetActive(true);
    }


    private void OnDisable()
    {
        _blindSelector.BlindSelected -= OnBlindSelected;
    }
}