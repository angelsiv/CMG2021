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
        Instantiate(projectile, transform.position, UnityEngine.Quaternion.identity);
    }

    public override void OnDamage(int damage, MixedOutputType attacktype)
    {
        switch (attacktype)
        {
            case MixedOutputType.Water:
                health -= damage;
                break;
            case MixedOutputType.Fire:
                health -= damage;
                break;
            case MixedOutputType.Acid:
                health -= damage * 3;
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
