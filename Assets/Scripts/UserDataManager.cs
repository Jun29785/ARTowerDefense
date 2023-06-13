using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public UserData userData;
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/data.json";
        if (!File.Exists(filePath))
        {
            InitializeData();
            SaveData();
        }
        LoadData();
    }

    public void InitializeData()
    {
        Debug.Log("Initialize Data");
        userData.ranks = new List<RankData>();
        userData.Coin = 0;
        userData.UserHP = 1;
        userData.ClickDamage = 1;
        userData.SubTowerAmount = 1;
    }

    public void SaveData()
    {
        Debug.Log("Save Data");
        string dataAsJson = JsonUtility.ToJson(userData);
        File.WriteAllText(filePath, dataAsJson);
    }

    public void LoadData()
    {
        Debug.Log("Load Data");
        string data = File.ReadAllText(filePath);
        userData = JsonUtility.FromJson<UserData>(data);
    }
}

[System.Serializable]
public class UserData
{
    public List<RankData> ranks;
    public int Coin;
    public int UserHP;
    public int ClickDamage;
    public int SubTowerAmount;
}