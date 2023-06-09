using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<UserData> users;

    public int maxSubTower = 3;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

public class UserData
{
    public string Name;
    public int FinalWave;

    public UserData()
    {

    }

    public UserData(string name, int finalWave)
    {
        Name = name;
        FinalWave = finalWave;
    }
}