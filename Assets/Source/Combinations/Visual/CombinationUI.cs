using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CombinationUI : MonoBehaviour
{
    [SerializeField] private Transform _combinationSlotParent;
    [SerializeField] private CombinationUISlot _combinationUiSlotPrefab;
    [SerializeField] private GameObject _combinationPanel;

    private CombinationContainer _combinationContainer;

    [Inject]
    public void Construct(CombinationContainer combinationContainer)
    {
        _combinationContainer = combinationContainer;
    }

    public void OpenClosePanel()
    {
        _combinationPanel.SetActive(!_combinationPanel.activeInHierarchy);
    }

    private void Start()
    {
        for (int i = 0; i < _combinationContainer.Combinations.Length; i++)
        {
            CombinationUISlot combinationUiSlot = Instantiate(_combinationUiSlotPrefab, _combinationSlotParent);
            combinationUiSlot.Init(_combinationContainer.Combinations[i]);
        }
    }
}