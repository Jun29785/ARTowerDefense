using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform target;

    private void Start()
    {
        Destroy(gameObject, 1.2f);
    }
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyObject>().hitEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
