using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck/Config")]
public class DeckConfig : ScriptableObject, IDeckCharacteristicsChangeable
{
    [field: SerializeField] public int DeckDefaultCapacity { get; set; }
    public void Change(int value)
    {
        Debug.Log("CHANGED SMSNFH");
        DeckDefaultCapacity = value;
    }
}
