using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private int price;
    public Vector3 towerPosition;
    private InGameManager inGameManager;

    void Start()
    {
        inGameManager = InGameManager.Instance;
    }

    void Update()
    {

    }

    public void TowerBuildActive(bool active)
    {
        if (active)
        {
            price = 15 * ((inGameManager.waveManager.currentWave / 5) + 1) * (inGameManager.subTowerCount + 1);
            priceText.text = $"¨Ï {price}";
        }
        gameObject.SetActive(active);
    }

    public void OnClickYesButton()
    {
        if (inGameManager.playCoin >= price)
        {
            inGameManager.playCoin -= price;
            inGameManager.SubTowerBuild(towerPosition);
        }
    }
}
