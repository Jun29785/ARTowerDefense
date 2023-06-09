using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCalc : MonoBehaviour
{
    public Transform subTowerPlatform;
    public int subTowerCount;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            subTowerLocation();
    }

    public void subTowerLocation()
    {
        subTowerCount = subTowerPlatform.childCount;
        for (int i = 0; i < subTowerCount; i++)
        {
            float angle = i * Mathf.PI * 2f / subTowerCount;
            Debug.Log($"radian : {angle}");
            float x = Mathf.Cos(angle) * 2.5f;
            float z = Mathf.Sin(angle) * 2.5f;
            subTowerPlatform.GetChild(i).position = new Vector3(x, 0, z);
        }
    }
}
