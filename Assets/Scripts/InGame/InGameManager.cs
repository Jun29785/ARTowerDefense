using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public ObjectSpawnManager objectSpawnManager;
    public Transform Core;
    public GameObject CorePrefab;

    [Header("Spawner")]
    [SerializeField] private Transform[] spawners;
    [SerializeField] private float curSpawnerDelay;
    [SerializeField] [Range(0f,10f)] private float maxSpawnerDuration;

    [Header("Materials")]
    public Material[] enemyColor;

    [Header("Game")]
    public bool isCoreBuild = false;
    public bool isWave = false;
    public int playCoin;
    public MainCanvas canvas;

    [Header("Wave")]
    public int currentWave;
    public UnityEvent nextWave;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        nextWave.AddListener(WaveStart);
    }

    void Update()
    {
        curSpawnerDelay += Time.deltaTime;
        if (curSpawnerDelay>maxSpawnerDuration && isWave)
        {
            curSpawnerDelay = 0f;
            EnemySpawn();
        }
    }

    public void CoreBuild(Vector3 position)
    {
        GameObject core = Instantiate(CorePrefab);
        core.transform.position = position;
        Core = core.transform;
        isCoreBuild = true;
        GetComponent<RayManager>().arPlaneManager.SetTrackablesActive(false);
        nextWave.Invoke();
    }

    public void GameInitialize()
    {
        currentWave = 0;
    }

    IEnumerator WaveStartAnimation()
    {
        yield return new WaitForSeconds(3f);
    }

    void WaveStart()
    {
        currentWave++;
        StartCoroutine(WaveStartAnimation());
    }

    void EnemySpawn()
    {
        spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().spawn.Invoke();
    }

    public void EnemyDie(Transform enemy)
    {
        Destroy(enemy.gameObject);
        playCoin++;
    }

    public void CoreCollision(EnemyObject enemy)
    {
        objectSpawnManager.enemyPool.Release(enemy);
    }
}