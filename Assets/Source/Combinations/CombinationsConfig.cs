using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combination/New Combination Config")]
public class CombinationsConfig : ScriptableObject
{
    [field: SerializeField] public Combination[] Combinations { get; private set; }
}