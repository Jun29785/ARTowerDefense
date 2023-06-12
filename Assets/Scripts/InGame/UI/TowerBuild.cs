using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private int price;
    public Vector3 towerPosition;

    void Start()
    {
    }

    void Update()
    {

    }

    public void TowerBuildActive(bool active)
    {
        if (active)
        {
            price = 15 * ((InGameManager.Instance.waveManager.currentWave / 5) + 1) * (InGameManager.Instance.subTowerCount + 1);
            priceText.text = $"¨Ï {price}";
        }
        gameObject.SetActive(active);
    }

    public void OnClickYesButton()
    {
        var inGameManager = InGameManager.Instance;
        if (inGameManager.playCoin >= price)
        {
            inGameManager.playCoin -= price;
            inGameManager.SubTowerBuild(towerPosition);
            TowerBuildActive(false);
        }
    }

    public void OnClickNoButton()
    {
        TowerBuildActive(false);
    }
}
