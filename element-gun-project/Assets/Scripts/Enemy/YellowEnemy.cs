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
        Projectile projectileToSpawn = Instantiate(projectile, transform.position, new UnityEngine.Quaternion(transform.forward.x, transform.forward.y, 0.0f, transform.rotation.w));
        projectileToSpawn.gameObject.SetActive(true);
    }

    public override void OnDamage(int damage, int attacktype)
    {
    }

}
