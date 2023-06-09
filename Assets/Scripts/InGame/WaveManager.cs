using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int baseEnemy = 3;
    public int currentWave;
    public int remainEnemy;

    public void WaveInit()
    {
        remainEnemy = baseEnemy * ((currentWave/ 3) + 1);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
