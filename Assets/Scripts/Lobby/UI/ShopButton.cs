using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI priceText;

    [SerializeField] [Range(0,3)] private int StatNo;
    private int price;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ButtonTextUpdate(int level, int price)
    {
        levelText.text = $"<LV. {level}>";
        priceText.text = $"¨Ï {price}";
        this.price = price;
    }

    public void OnClickButton()
    {
        if (GameManager.Instance.userDataManager.userData.Coin >= price)
        {
            GameManager.Instance.userDataManager.userData.Coin -= price;
            LevelUP();
        }
    }

    public void LevelUP()
    {
        switch (StatNo)
        {
            case 0: // HP
                GameManager.Instance.userDataManager.userData.UserHP++;
                break;
            case 1: // Damage
                GameManager.Instance.userDataManager.userData.ClickDamage++;
                break;
            case 2: // SubTowerAmount
                GameManager.Instance.userDataManager.userData.SubTowerAmount++;
                break;
            default:
                break;
        }
        LobbyUIManager.Instance.canvas.shopManager.UpdateText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickButton();
    }
}
