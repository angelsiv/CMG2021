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

    public override void OnDamage(int damage, MixedOutputType attacktype)
    {
        switch (attacktype)
        {
            case MixedOutputType.Water:
                health -= damage;
                break;
            case MixedOutputType.Fire:
                health -= damage * 3;
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
