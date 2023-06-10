using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    public static LobbyUIManager Instance;

    public LobbyCanvas canvas;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {

    }

    public void OnClickGameStartButton()
    {
        GameManager.Instance.sceneController.SceneLoad("InGame");
    }

    public void OnClickShopButton()
    {
        canvas.shopManager.OpenShop();
    }

    public void OnClickRankButton()
    {
        GameManager.Instance.sceneController.SceneLoad("Rank");
    }

    public void OnClickExitButton()
    {
        canvas.exitGame.ExitGameActive(true);
    }
}
