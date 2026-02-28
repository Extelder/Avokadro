using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HandView : MonoBehaviour, IHandContainable
{
    [SerializeField] private RectTransform _rectTransform;
    [field: SerializeField] public RectTransform PlayHandParent;

    [Inject]
    public void Construct()
    {
        SetRect();
    }

    
    private void SetRect()
    {
        _rectTransform.anchorMin = Vector2.zero;
        _rectTransform.anchorMax = Vector2.one;
        _rectTransform.offsetMin = Vector2.zero;
        _rectTransform.offsetMax = Vector2.zero;
    }

    [field: SerializeField] public Transform DefaultSpawnParent { get; set; }
}