using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Hand/Playable")]
public class PlayableHandConfig : ScriptableObject
{
    [field: SerializeField] public float HandPlayCooldown { get; private set; }
}
