using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public static RankManager Instance;

    [SerializeField] private GameObject rankObject;
    [SerializeField] private Transform rankParent;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameManager.Instance.SortRank();
        SetRankObject();
    }

    void Update()
    {
        
    }

    void SetRankObject()
    {
        List<RankData> ranks = GameManager.Instance.rankUsers;
        
        foreach(Transform rank in rankParent)
        {
            Destroy(rank.gameObject);
        }

        for(int i = 0; i < ranks.Count; i++)
        {
            Instantiate(rankObject,rankParent).TryGetComponent<RankObject>(out RankObject rankObj);
            rankObj.TextUpdate(i + 1, ranks[i].Name, ranks[i].Wave);
        }
    }

    public void ExitRank()
    {
        GameManager.Instance.sceneController.SceneLoad("Lobby");
    }
}
