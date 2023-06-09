using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform target;

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 1 << LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<EnemyObject>().hitEvent.Invoke();
        }
    }
}
