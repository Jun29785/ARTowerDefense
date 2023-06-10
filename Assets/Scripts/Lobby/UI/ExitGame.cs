using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ExitGameActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void OnClickYesButton()
    {
        GameManager.Instance.userDataManager.SaveData();
        Application.Quit();
    }
}
