using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

abstract public class EnemyBase : MonoBehaviour
{
    /*public enum AIState
    {
        attackState,
        pasiveState
    }*/

    public enum EnemyType
    {
        red,
        blue,
        yellow
    }
    

    [SerializeField] private int health;

    [SerializeField] protected Projectile projectile;
    [SerializeField] protected Transform offset;
    [SerializeField] protected Transform playerPosition;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookRadius = 10f;

    protected EnemyType enemyType;
    protected bool bAttacking;

    private NavMeshAgent navMesh;


    abstract public void OnDamage(int damage, int attacktype);

    abstract public void Attack();

    protected void Update()
    {
        navMesh = GetComponent<NavMeshAgent>();
        float distance = UnityEngine.Vector3.Distance(playerPosition.position, transform.position);
        
        if (distance <= lookRadius)
        {
            navMesh.SetDestination(playerPosition.position);
            navMesh.speed = speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
