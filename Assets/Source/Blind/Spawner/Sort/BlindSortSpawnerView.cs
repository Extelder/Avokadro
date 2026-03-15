using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSortSpawnerView : MonoBehaviour, IBlindSortSpawnerViewable
{
    [field: SerializeField] public BlindConfigsKeeper BlindConfigsKeeper { get; set; }
}