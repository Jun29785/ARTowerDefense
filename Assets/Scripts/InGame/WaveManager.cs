using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int baseEnemy = 15;
    public int currentWave;
    public int remainEnemy;

    public void WaveInit()
    {
        remainEnemy = baseEnemy * currentWave;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
