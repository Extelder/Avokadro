using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TarotCardCharacteristics : TarotCharacteristics
{
    [Inject] private IDeckCharacteristicsChangeable _deckCharacteristicsChangeable;
    
    public override void ChangeValue(int value)
    {
        Debug.Log("DECK CHANGE");
        _deckCharacteristicsChangeable.Change(value);
    }
}
