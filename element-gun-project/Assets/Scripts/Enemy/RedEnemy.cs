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

    public override void Attack()
    {
        Instantiate(projectile, transform.position, UnityEngine.Quaternion.identity);
    }

    protected void Update()
    {
        base.Update();
    }

    public override void OnDamage(int damage, int attacktype)
    {

    }
}
