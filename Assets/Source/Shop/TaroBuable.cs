using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaroBuable : Buyable
{
    public override bool TryBuy()
    {
        Destroy(gameObject);
        return true;
    }
}