using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSpawnerView : MonoBehaviour, IBlindSpawnerViewable
{
    [field: SerializeField] public Transform Parent { get; set; }
}
