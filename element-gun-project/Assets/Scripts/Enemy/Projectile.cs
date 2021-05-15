using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    [SerializeField] private int damage = 1;


    protected void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
