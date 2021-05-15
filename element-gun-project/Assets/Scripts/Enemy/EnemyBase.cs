using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

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

    public enum EnemyLevel
    {
        lvl1,
        lvl2,
        lvl3
    }
    
    [SerializeField] private EnemyLevel enemyLevel;

    [SerializeField] private int health;

    [SerializeField] protected Projectile projectile;
    [SerializeField] protected Transform offset;
    protected Transform playerPosition;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookRadius = 15.0f;
    [SerializeField] private float stopRadius = 8.0f;

    protected EnemyType enemyType;
    protected bool bAttacking;

    private NavMeshAgent navMesh;


    abstract public void OnDamage(int damage, int attacktype);

    abstract public void Attack();

    protected void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void Update()
    {
        //FaceTarget();
        if (playerPosition != null)
        {
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }
        else
        {
            Console.WriteLine("player is null");
        }
        /*navMesh = GetComponent<NavMeshAgent>();
        float distance = UnityEngine.Vector3.Distance(playerPosition.position, transform.position);
        
        if (distance <= lookRadius)
        {
            navMesh.SetDestination(playerPosition.position);
            navMesh.speed = speed;
        }

        if (distance <= navMesh.stoppingDistance)
        {
            if (!bAttacking)
            {
                navMesh.speed = speed;
            }

            FaceTarget();
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {

        }
        
    }

    void FaceTarget()
    {
        //UnityEngine.Vector3 direction = (playerPosition.position - transform.position).normalized;
        //UnityEngine.Quaternion lookRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(direction.x, direction.y, 0));
        //transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }

}
