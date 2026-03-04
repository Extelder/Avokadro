using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Blind/Config", fileName = "Blind")]
public class BlindConfig : ScriptableObject
{
    [field: SerializeField] public bool HaveSpecialCondition { get; private set; }
    [field: ShowIf(nameof(HaveSpecialCondition))] [field: SerializeField]
    public BlindCondition BlindCondition { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int GoalScore { get; private set; }
}