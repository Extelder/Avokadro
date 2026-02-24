using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck/Config")]
public class DeckConfig : ScriptableObject
{
    [field: SerializeField] public int DeckDefaultCapacity { get; set; }
}
