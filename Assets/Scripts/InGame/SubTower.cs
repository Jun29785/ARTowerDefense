using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTower : MonoBehaviour
{
    public Transform targetEnemy;
    private int enemyLayer;
    [SerializeField] Transform FirePos;

    private int range = 3;

    private float curDelay = 0f;
    [SerializeField] private float maxDuration = 2.5f;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Update()
    {
        if (targetEnemy == null || !targetEnemy.gameObject.activeSelf)
        {
            GetTargetEnemy();
        }
        else
        {
            curDelay += Time.deltaTime;
            if (curDelay > maxDuration)
            {
                curDelay = 0f;
                AttackFunc();
            }
            if (Vector3.Distance(targetEnemy.position, transform.position) > range)
                targetEnemy = null;
        }
    }

    void AttackFunc()
    {
        InGameManager.Instance.SubTowerAttack(FirePos);
    }

    void GetTargetEnemy()
    {
        targetEnemy = null;
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, range, 1 << enemyLayer);
        if (enemyColliders.Length == 0) return;
        else
        {
            targetEnemy = GetCloset(enemyColliders);
        }
    }

    Transform GetCloset(Collider[] colliders)
    {
        Transform target = null;
        float closetdis = float.PositiveInfinity;
        foreach(Collider col in colliders)
        {
            float distance = Vector3.Distance(transform.position, col.transform.position);
            if (distance < closetdis)
            {
                target = col.transform;
                closetdis = distance;
            }
        }
        return target;
    }
}
