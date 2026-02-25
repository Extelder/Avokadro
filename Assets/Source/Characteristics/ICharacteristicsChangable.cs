using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacteristicsChangable<T>
{
    public void Change(T value);
}
