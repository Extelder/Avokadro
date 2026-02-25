using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour, IScoreViewable
{
    [field: SerializeField] public TextMeshProUGUI ScoreValueText { get; set; }

    public void ChangeVisual(int value)
    {
        ScoreValueText.text = value.ToString();
    }
}