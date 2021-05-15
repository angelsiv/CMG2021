using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    [SerializeField] private int damage = 1;

    private int dir = 1;

    protected void Update()
    {
        transform.position += (transform.right*(dir)) * Time.deltaTime * speed;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
