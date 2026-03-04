using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BlindCondition
{
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeReference]
    [field: SerializeReferenceButton]
    [field: SerializeField]
    public BlindConditions BlindConditions { get; private set; }
}

public abstract class BlindConditions
{
    public abstract void Use();
}