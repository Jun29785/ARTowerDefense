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
        var user = GameManager.Instance.userDataManager.userData;
        gameObject.SetActive(true);
        GameManager.Instance.userDataManager.userData.Coin += InGameManager.Instance.playCoin;
        waveText.text = $"{InGameManager.Instance.waveManager.currentWave} ¿şÀÌºê";
        coinText.text = $"+ ¨Ï {InGameManager.Instance.playCoin}";

        if (user.ranks.Count > 0)
        {
            if (user.ranks.Count < 5 || user.ranks[user.ranks.Count - 1].Wave <= InGameManager.Instance.waveManager.currentWave)
            {
                rankRegister.gameObject.SetActive(true);
            }
            else
            {
                rankRegister.gameObject.SetActive(false);
            }
        }
        else rankRegister.gameObject.SetActive(true);
        GameManager.Instance.SortRank();
        GameManager.Instance.userDataManager.SaveData();
    }

    public void RegisterRank()
    {
        var gm = GameManager.Instance;
        if (rankRegister.text.Length == 3)
        {
            RankData rank = new RankData(rankRegister.text, InGameManager.Instance.waveManager.currentWave);
            gm.userDataManager.userData.ranks.Add(rank);
            gm.SortRank();
            gm.userDataManager.SaveData();
            rankRegister.gameObject.SetActive(false);

        }
    }

    public void RankScene()
    {
        GameManager.Instance.sceneController.SceneLoad("Rank");
    }
}
