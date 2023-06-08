using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;
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
    public WaveManager waveManager;
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
        if (Input.GetKeyDown(KeyCode.Space)) CoreBuild(new Vector3(-3, 2, 1));
        if (isWave)
        {
            canvas.gameUI.TextUpdate(waveManager.currentWave, playCoin, waveManager.remainEnemy);
            curSpawnerDelay += Time.deltaTime;
            if (curSpawnerDelay > maxSpawnerDuration)
            {
                curSpawnerDelay = 0f;
                EnemySpawn();
            }

        }
    }

    public void CoreBuild(Vector3 position)
    {
        GameObject core = Instantiate(CorePrefab);
        core.transform.position = position;
        Core = core.transform;
        isCoreBuild = true;
        GetComponent<RayManager>().arPlaneManager.SetTrackablesActive(false);
        GetComponent<RayManager>().arPlaneManager.enabled = false;
        foreach(Transform spawner in spawners)
        {
            spawner.position += Core.position;
        }
        nextWave.Invoke();
    }

    public void GameInitialize()
    {
        waveManager.currentWave = 0;
    }

    IEnumerator StartWave()
    {
        isWave = false;
        canvas.gameUI.GameUIActive(false);
        canvas.waveNotice.WaveNoticeActive(true);
        yield return new WaitForSeconds(1.5f);
        waveManager.WaveInit();
        canvas.waveNotice.WaveNoticeActive(false);
        canvas.gameUI.GameUIActive(true);
        isWave = true;
    }

    void WaveStart()
    {
        waveManager.currentWave++;
        StartCoroutine(StartWave());
    }

    void EnemySpawn()
    {
        spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().spawn.Invoke();
    }

    public void EnemyDie(EnemyObject enemy)
    {
        objectSpawnManager.enemyPool.Release(enemy);
        playCoin++;
    }

    public void CoreCollision(EnemyObject enemy)
    {
        objectSpawnManager.enemyPool.Release(enemy);
    }
}