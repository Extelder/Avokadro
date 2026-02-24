using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeckContainable
{
    public event Action Started;
    public CardData[] CardDatas { get; set; }
}
