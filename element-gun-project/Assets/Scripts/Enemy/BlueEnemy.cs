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

    // Start is called before the first frame update
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
