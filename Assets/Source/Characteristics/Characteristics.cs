using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characteristics<T>
{
    public T CurrentValue { get; set; }

    public virtual void ChangeValue(T value)
    {
        CurrentValue = value;
    }
}
