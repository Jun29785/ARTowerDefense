using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public ObjectSpawnManager objectSpawnManager;
    public Transform Core;

    [Header("Spawner")]
    [SerializeField] private Transform[] spawners;
    [SerializeField] private float curSpawnerDelay;
    [SerializeField] [Range(0f,10f)] private float maxSpawnerDuration;

    [Header("Materials")]
    public Material[] enemyColor;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        curSpawnerDelay += Time.deltaTime;
        if (curSpawnerDelay>maxSpawnerDuration)
        {
            curSpawnerDelay = 0f;
            EnemySpawn();
        }
    }

    void EnemySpawn()
    {
        spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().spawn.Invoke();
    }

    public void CoreCollision(EnemyObject enemy)
    {
        objectSpawnManager.enemyPool.Release(enemy);
    }
}
