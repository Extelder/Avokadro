using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour, IHandContainable
{
    public void SpawnCard(Card cardToSpawn)
    {
    }

    [field: SerializeField] public Transform DefaultSpawnParent { get; set; }
}
