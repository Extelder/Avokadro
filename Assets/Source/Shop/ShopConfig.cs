using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Config")]
public class ShopConfig : ScriptableObject
{
    [field: SerializeField] public List<Buyable> Buyables { get; private set; }
    [field: SerializeField] public int NumberOfBuyables { get; private set; }
}