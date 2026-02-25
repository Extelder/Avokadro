using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Score/Config")]
public class ScoreConfig : ScriptableObject
{
    [field: SerializeField] public int MinValue { get; private set; }
    [field: SerializeField] public int StartValue { get; private set; }
}
