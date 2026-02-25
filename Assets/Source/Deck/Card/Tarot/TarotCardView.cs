using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCardView : MonoBehaviour, ITarotCardViewable
{
    [field: SerializeReferenceButton]
    [field: SerializeReference]
    [field: SerializeField]
    public TarotCharacteristics TarotCharacteristics { get; set; }
}