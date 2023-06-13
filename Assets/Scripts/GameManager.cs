using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SceneController sceneController;
    public UserDataManager userDataManager;

    public int maxSubTower = 3;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SortRank()
    {
        userDataManager.userData.ranks.Sort((a, b) => b.Wave.CompareTo(a.Wave));
    }
}

[System.Serializable]
public class RankData
{
    public string Name;
    public int Wave;

    public RankData()
    {

    }

    public RankData(string name, int wave)
    {
        Name = name;
        Wave = wave;
    }
}