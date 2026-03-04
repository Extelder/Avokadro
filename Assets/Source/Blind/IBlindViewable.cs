using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IBlindViewable
{
    public BlindConfig BlindConfig { get; set; }
    public Image Image { get; set; }
    public Button PlayButton { get; set; }
    public TextMeshProUGUI MinScore { get; set; }
    public TextMeshProUGUI BlindName { get; set; }
    
    public void Spawned(BlindConfig blindConfig);
}
