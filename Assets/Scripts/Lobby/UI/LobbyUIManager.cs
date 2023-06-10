using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    public LobbyCanvas canvas;

    void Start()
    {

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
