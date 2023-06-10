using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public List<ShopButton> shops;
    public TextMeshProUGUI coinText;

    private void OnEnable()
    {
        UpdateText();
    }

    void Update()
    {
        coinText.text = $"¨Ï {GameManager.Instance.userDataManager.userData.Coin}";
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void UpdateText()
    {
        var gm = GameManager.Instance.userDataManager.userData;
        int level = 0, price = 0;

        for (int i = 0; i < shops.Count; i++)
        {
            switch (i)
            {
                case 0: // hp
                    level = gm.UserHP;
                    price = gm.UserHP * 1000;
                    break;
                case 1: // damage
                    level = gm.ClickDamage;
                    price = gm.ClickDamage * 1200;
                    break;
                case 2: // tower amount
                    level = gm.SubTowerAmount;
                    price = gm.SubTowerAmount * 3000;
                    break;
                default:
                    break;
            }
            shops[i].ButtonTextUpdate(level, price);
        }
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
