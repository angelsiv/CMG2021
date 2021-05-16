using UnityEngine;

public class BlueEnemy : EnemyBase
{
    private void Awake()
    {
        this.enemyType = EnemyType.blue;
    }
    public override void Attack()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    public override void OnDamage(int damage, int attacktype)
    {
    }
}
