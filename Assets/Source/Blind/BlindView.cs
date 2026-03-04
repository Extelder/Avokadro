using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlindView : MonoBehaviour, IBlindViewable
{
    [field: SerializeField] public BlindConfig BlindConfig { get; set; }
    [field: SerializeField] public Image Image { get; set; }
    [field: SerializeField] public Button PlayButton { get; set; }
    [field: SerializeField] public TextMeshProUGUI MinScore { get; set; }
    [field: SerializeField] public TextMeshProUGUI BlindName { get; set; }
    
    public void Spawned(BlindConfig blindConfig)
    {
        Image.sprite = blindConfig.Sprite;
        MinScore.text = blindConfig.GoalScore.ToString();
        BlindName.text = blindConfig.Name;
    }
}
