using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class RedEnemy : EnemyBase
{
    private void Awake()
    {
        this.enemyType = EnemyType.red;
    }

    void Start()
    {
    }

    public override void Attack()
    {
        Instantiate(projectile, offset.position, transform.rotation);
    }

    public override void OnDamage(int damage, int attacktype)
    {

    }
}
