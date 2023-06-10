using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public UserData userData;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SaveData()
    {
        string dataAsJson = JsonUtility.ToJson(userData);
        string filePath = Application.persistentDataPath + "/data.json";
        File.WriteAllText(filePath, dataAsJson);
    }

    public void LoadData()
    {
        
    }
}

[System.Serializable]
public class UserData{
    public List<RankData> ranks;
    public int Coin;
    public int UserHP;
    public int ClickDamage;
    public int SubTowerAmount;
}