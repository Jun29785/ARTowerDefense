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

public class UserData{

}