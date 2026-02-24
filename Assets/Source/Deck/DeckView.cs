using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckView : MonoBehaviour, IDeckContainable
{
    public event Action Started;
    [field: SerializeField] public CardData[] CardDatas { get; set; }

    private void Start()
    {
        Started?.Invoke();
    }
}
