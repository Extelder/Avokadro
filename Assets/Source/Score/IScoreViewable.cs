using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IScoreViewable
{
    public TextMeshProUGUI ScoreValueText { get; set; }
    public void ChangeVisual(int value);
}
