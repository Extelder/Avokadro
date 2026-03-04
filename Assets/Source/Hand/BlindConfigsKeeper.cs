using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Blind/BlindsKeeper")]
public class BlindConfigsKeeper : ScriptableObject
{
    [field: SerializeField] public BlindConfig SmallBlind { get; private set; }
    [field: SerializeField] public BlindConfig BigBlind { get; private set; }
    [field: SerializeField] public BlindConfig[] SpecialBlinds { get; private set; }
}
