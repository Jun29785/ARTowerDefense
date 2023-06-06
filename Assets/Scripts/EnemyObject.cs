using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class EnemyObject : MonoBehaviour
{
    private IObjectPool<EnemyObject> enemyPool;

    private Vector3 direction;

    [SerializeField] [Range(0f,10f)] private float speed;
    public int HP;

    public UnityEvent hitEvent;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        hitEvent.AddListener(GetHit);
    }

    void Update()
    {
        direction = (InGameManager.Instance.Core.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void GetHit()
    {
        HP--;
        int hp = (HP % 7); 
        renderer.material = InGameManager.Instance.enemyColor[hp];
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
