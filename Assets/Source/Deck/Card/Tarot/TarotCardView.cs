using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TarotCardView : MonoBehaviour, ITarotCardViewable
{
    [field: SerializeReferenceButton]
    [field: SerializeReference]
    [field: SerializeField]
    public TarotCharacteristics TarotCharacteristics { get; set; }

    [Inject] private DiContainer _container;


    private void Awake()
    {
        TarotCharacteristics.Inject(_container);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Use();
            Debug.Log("KEY");
        }
    }

    public event Action Used;

    public void Use()
    {
        Used?.Invoke();
    }
}