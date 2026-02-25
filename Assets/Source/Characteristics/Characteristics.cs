using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Characteristics<T>
{
    public virtual void Inject(DiContainer container)
    {
        container.Inject(this);
    }
    public abstract void ChangeValue(T value);
}
