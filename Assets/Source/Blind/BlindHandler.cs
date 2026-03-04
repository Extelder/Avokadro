using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindHandler : IDisposable
{
    private Blind _blind;
    
    public BlindHandler(Blind blind)
    {
        _blind = blind;
    }

    private void OnBlindSetUped()
    {
    }

    public void Dispose()
    {
    }
}
