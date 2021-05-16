using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BlueEnemy : EnemyBase
{
    private void Awake()
    {
        this.enemyType = EnemyType.blue;
    }
    public override void Attack()
    {
        Projectile projectileToSpawn = Instantiate(projectile, offset.position, transform.rotation);
        projectileToSpawn.gameObject.SetActive(true);
        
    }

    public override void OnDamage(int damage, int attacktype)
    {
    }
}
