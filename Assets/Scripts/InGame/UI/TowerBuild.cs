using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    void Start()
    {

    }

    void Update()
    {

    }

    public void TowerBuildActive(bool active)
    {
        if (active)
            priceText.text = $"¨Ï {15 * ((InGameManager.Instance.waveManager.currentWave / 5) + 1) * (InGameManager.Instance.subTowerCount + 1)}";
    }
}
