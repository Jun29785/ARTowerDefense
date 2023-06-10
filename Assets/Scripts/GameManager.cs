using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SceneController sceneController;
    public UserDataManager userDataManager;

    public List<RankData> users;

    public int maxSubTower = 3;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

public class RankData
{
    public string Name;
    public int FinalWave;

    public RankData()
    {

    }

    public RankData(string name, int finalWave)
    {
        Name = name;
        FinalWave = finalWave;
    }
}