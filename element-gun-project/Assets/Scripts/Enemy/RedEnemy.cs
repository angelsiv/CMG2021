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
        Projectile projectileToSpawn = Instantiate(projectile, transform.position, new UnityEngine.Quaternion(transform.forward.x, transform.forward.y, 0.0f, transform.rotation.w));
        projectileToSpawn.gameObject.SetActive(true);
    }

    protected void Update()
    {
        base.Update();

       Attack();
    }

    public override void OnDamage(int damage, int attacktype)
    {

    }
}
