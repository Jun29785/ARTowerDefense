using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankObject : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI rankName;
    public TextMeshProUGUI rankWave;

    void Start()
    {
        
    }
    
    public void TextUpdate(int rank, string name, int wave)
    {
        rankText.text = $"{rank}";
        rankName.text = $"{name}";
        rankWave.text = $"¿þÀÌºê {wave}";
    }
}
