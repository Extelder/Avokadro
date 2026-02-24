using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandContainable
{
    public void SpawnCard(Card cardToSpawn);
    public Transform DefaultSpawnParent { get; set; }
}
