using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hand/Config")]
public class HandConfig : ScriptableObject
{
    [field: SerializeField] public int CardsCapacity { get; set; }
}
