using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopSpawnInput
{
    [field: SerializeField] public Transform SpawnPoint { get; set; }
}