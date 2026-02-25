using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCard : IDisposable
{
    private ITarotCardViewable _tarotCardViewable;
    
    public TarotCard(ITarotCardViewable tarotCardViewable)
    {
        _tarotCardViewable = tarotCardViewable;
        _tarotCardViewable.Used += OnUsed;
    }

    private void OnUsed()
    {
        Debug.Log("CHANGE");
        _tarotCardViewable.TarotCharacteristics.ChangeValue(10);
    }

    public void Dispose()
    {
        _tarotCardViewable.Used -= OnUsed;
    }
}
