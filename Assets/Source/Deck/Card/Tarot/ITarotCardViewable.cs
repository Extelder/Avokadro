using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarotCardViewable
{
    public void Use();
    public event Action Used;
    public TarotCharacteristics TarotCharacteristics { get; set; }
}
