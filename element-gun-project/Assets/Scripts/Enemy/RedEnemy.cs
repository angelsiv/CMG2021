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

    public override void OnDamage(int damage, MixedOutputType attacktype)
    {
        switch (attacktype)
        {
            case MixedOutputType.Water:
                health -= damage * 3;
                break;
            case MixedOutputType.Fire:
                health -= damage;
                break;
            case MixedOutputType.Acid:
                health -= damage;
                break;
            case MixedOutputType.None:
                health -= damage;
                break;
        }

        if (health <= 0)
        {
            Dead();
        }
    }

    
}
