using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public UnityEvent spawn;

    void Start()
    {
        spawn.AddListener(SpawnEnemy);
    }

    void SpawnEnemy()
    {
        InGameManager.Instance.objectSpawnManager.SpawnEnemy(transform);
    }
}
