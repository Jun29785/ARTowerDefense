using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyObject enemyPrefab;
    public Transform enemyObjParent;
    [SerializeField] Transform enemyStore;

    public IObjectPool<EnemyObject> enemyPool;
    [SerializeField] [Range(0, 100)] private int poolSize=30;
    [SerializeField] [Range(0f, 10f)] private float spawnRange;
    private float baseEnemySpeed = 0.3f;

    void Start()
    {
        enemyPool = new ObjectPool<EnemyObject>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, OnDestroyEnemy, maxSize: poolSize);
    }

    void Update()
    {
        
    }

    #region Pool
    private EnemyObject CreateEnemy()
    {
        EnemyObject enemy = Instantiate(enemyPrefab);
        enemy.SetPool(enemyPool);
        return enemy;
    }

    private void OnGetEnemy(EnemyObject enemy)
    {
        enemy.gameObject.SetActive(true);
    }
    
    private void OnReleaseEnemy(EnemyObject enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.transform.parent = enemyStore;
    }

    private void OnDestroyEnemy(EnemyObject enemy)
    {
        Destroy(enemy.gameObject);
    }
    #endregion

    public void SpawnEnemy(Transform spawner)
    {
        var enemy = enemyPool.Get();
        Vector3 pos = new Vector3(spawner.position.x + Random.Range(-spawnRange, spawnRange), spawner.position.y + Random.Range(-(spawnRange), (spawnRange)), spawner.position.z + Random.Range(-spawnRange, spawnRange));
        enemy.transform.position = pos;
        enemy.transform.parent = enemyObjParent;
        enemy.speed = ((InGameManager.Instance.waveManager.currentWave / 5) + 1) * baseEnemySpeed;
        enemy.HP = InGameManager.Instance.waveManager.currentWave * 3;
    }
}
