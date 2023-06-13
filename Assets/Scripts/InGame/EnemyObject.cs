using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class EnemyObject : MonoBehaviour
{
    private IObjectPool<EnemyObject> enemyPool;

    private Vector3 direction;

    [Range(0f, 10f)] public float speed;
    [SerializeField] private int hp;
    public int HP { get { return hp; } set { hp = value; GetComponent<Renderer>().material = InGameManager.Instance.enemyColor[HP % 7]; } } 

    public UnityEvent hitEvent;

    void Start()
    {
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
            Handheld.Vibrate();
            InGameManager.Instance.CoreCollision(this);
        }
    }

    void GetHit()
    {
        Debug.Log("hit");
        HP -= GameManager.Instance.userDataManager.userData.ClickDamage;
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
