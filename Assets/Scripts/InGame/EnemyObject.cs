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

    private Renderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        hitEvent.AddListener(GetHit);
    }

    private void OnEnable()
    {
        
    }

    void Update()
    {
        direction = (InGameManager.Instance.Core.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, InGameManager.Instance.Core.position) <= 0.1f)
        {
            InGameManager.Instance.CoreCollision(this);
        }
    }

    void GetHit()
    {
        HP--;
        int hp = (HP % 7); 
        mesh.material = InGameManager.Instance.enemyColor[hp];
        if (HP <= 0)
        {
            InGameManager.Instance.EnemyDie(this);
        }
    }

    public void SetPool(IObjectPool<EnemyObject> pool)
    {
        enemyPool = pool;
    }
}
