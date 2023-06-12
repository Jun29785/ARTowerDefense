using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TMP_InputField rankRegister;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOverActive()
    {
        gameObject.SetActive(true);
        waveText.text = $"{InGameManager.Instance.waveManager.currentWave} ¿þÀÌºê";
        coinText.text = $"+ ¨Ï {InGameManager.Instance.playCoin}";

        if (GameManager.Instance.rankUsers[GameManager.Instance.rankUsers.Count-1].Wave  <= InGameManager.Instance.waveManager.currentWave)
        {
            rankRegister.gameObject.SetActive(true);
        }
        else
        {
            rankRegister.gameObject.SetActive(false);
        }
    }

    public void RegisterRank()
    {
        if (rankRegister.text.Length == 3)
        {
            RankData rank = new RankData(rankRegister.text, InGameManager.Instance.waveManager.currentWave);
            GameManager.Instance.rankUsers.Add(rank);
            GameManager.Instance.SortRank();
            rankRegister.gameObject.SetActive(false);
        }
    }

    public void RankScene()
    {
        GameManager.Instance.sceneController.SceneLoad("Rank");
    }
}
