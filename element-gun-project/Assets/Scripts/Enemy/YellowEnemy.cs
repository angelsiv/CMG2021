using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : EnemyBase
{
    void Awake()
    {
        this.enemyType = EnemyType.yellow;

    }

    public override void Attack()
    {
        Instantiate(projectile, offset.position, transform.rotation);
    }

    public override void OnDamage(int damage, int attacktype)
    {
    }

}
