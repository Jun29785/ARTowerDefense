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
    public GameObject SubtowerPrefab;
    public GameObject bulletPrefab;

    [Header("Spawner")]
    [SerializeField] private Transform[] spawners;
    [SerializeField] private float curSpawnerDelay;
    [SerializeField] [Range(0f,10f)] private float maxSpawnerDuration;

    [Header("Materials")]
    public Material[] enemyColor;

    [Header("Game")]
    public bool isCoreBuild = false;
    public bool isWave = false;
    public int maxHp;
    public int currentHp = 10;
    public int playCoin;
    public int subTower;
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
        canvas.gameUI.HPUpdate(maxHp, currentHp);
        if (isWave)
        {
            if (waveManager.remainEnemy <= 0 && objectSpawnManager.enemyObjParent.childCount == 0)
            {
                isWave = false;
                canvas.gameUI.GameUIActive(false);
                canvas.nextWaveButton.NextWaveActive(true);
            }
            canvas.gameUI.TextUpdate(waveManager.currentWave, playCoin, objectSpawnManager.enemyObjParent.childCount);
            
            curSpawnerDelay += Time.deltaTime;
            if (curSpawnerDelay > maxSpawnerDuration && waveManager.remainEnemy > 0)
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
            spawner.position = new Vector3(spawner.position.x, Core.position.y, spawner.position.z);
        }
        GameInitialize();
        nextWave.Invoke();
    }

    public void SubTowerBuild(Vector3 position)
    {
        GameObject subTower = Instantiate(SubtowerPrefab);
        subTower.transform.position = position;
    }

    public void GameInitialize()
    {
        waveManager.currentWave = 0;
        currentHp = maxHp;
    }

    IEnumerator StartWave()
    {
        canvas.waveNotice.WaveNoticeText(waveManager.currentWave);
        canvas.waveNotice.WaveNoticeActive(true);
        yield return new WaitForSeconds(1.5f);
        canvas.nextWaveButton.NextWaveActive(false);
        waveManager.WaveInit();
        canvas.waveNotice.WaveNoticeActive(false);
        canvas.gameUI.GameUIActive(true);
        isWave = true;
    }

    void WaveStart()
    {
        waveManager.currentWave++;
        if (waveManager.currentWave % 5 == 0)
        {
            foreach (Transform spawn in spawners)
                spawn.position *= 1.2f;
        }
        StartCoroutine(StartWave());
    }

    public void SubTowerAttack(Transform tower)
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.position = tower.position;
        obj.TryGetComponent<Bullet>(out Bullet bullet);
        bullet.target = tower.GetComponent<SubTower>().targetEnemy;
    }

    void EnemySpawn()
    {
        waveManager.remainEnemy--;
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
        currentHp--;
    }
}