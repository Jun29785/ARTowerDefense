using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObject : MonoBehaviour
{
    private IObjectPool<EnemyObject> enemyPool;

    private Vector3 direction;

    [SerializeField] [Range(0f,10f)] private float speed;

    void Start()
    {

    }

    void Update()
    {
        direction = (InGameManager.Instance.Core.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetPool(IObjectPool<EnemyObject> pool)
    {
        enemyPool = pool;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Core"))
        {
            InGameManager.Instance.CoreCollision(this);

        }
    }
}
