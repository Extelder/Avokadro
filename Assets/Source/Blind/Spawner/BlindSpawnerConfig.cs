using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Blind/Spawner")]
public class BlindSpawnerConfig : ScriptableObject
{
    [field: SerializeField] public int BlindsCountOnRound { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
}
