using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

abstract public class EnemyBase : MonoBehaviour
{
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

    [SerializeField] Mesh[] enemyLevelMesh;

    [SerializeField] private EnemyLevel enemyLevel;

    [SerializeField] private int health;
    [SerializeField] private float startTimer;

    [SerializeField] protected Projectile projectile;
    protected Transform playerPosition;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookRadius = 15.0f;
    [SerializeField] private float idleRadius = 10.0f;
    [SerializeField] private float stopRadius = 5.0f;

    protected EnemyType enemyType;
    protected bool bAttacking;
    private float timer;

    abstract public void OnDamage(int damage, int attacktype);

    abstract public void Attack();

    protected void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        switch (enemyLevel)
        {
            case EnemyLevel.lvl1:
                gameObject.GetComponent<MeshFilter>().mesh = enemyLevelMesh[0];
                break;
            case EnemyLevel.lvl2:
                gameObject.GetComponent<MeshFilter>().mesh = enemyLevelMesh[1];
                transform.localScale = transform.localScale * 2;
                break;
            case EnemyLevel.lvl3:
                gameObject.GetComponent<MeshFilter>().mesh = enemyLevelMesh[2];
                transform.localScale = transform.localScale * 5;
                break;
        }

        timer = startTimer;
    }

    protected void Update()
    {
        float playerDistance = Vector2.Distance(playerPosition.position, transform.position);

        if (playerPosition != null)
        {
            if (lookRadius > playerDistance)
            {
                if (idleRadius < playerDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
                }
                else if (idleRadius > playerDistance && stopRadius < playerDistance)
                {
                    transform.position = this.transform.position;
                }
                else if (stopRadius > playerDistance)
                {
                    transform.position = (Vector2.MoveTowards(transform.position, playerPosition.position, -speed * Time.deltaTime));

                }
            }

            if (timer <= 0)
            {
                Attack();
                timer = startTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            Console.WriteLine("player is null");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.CompareTag("player"))
        {

        }*/

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, idleRadius);
    }

}
