using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Config")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public int Discards { get; private set; }
    [field: SerializeField] public int Hands { get; private set; }
    [field: SerializeField] public int CardsToPlayCapacity { get; private set; }
}