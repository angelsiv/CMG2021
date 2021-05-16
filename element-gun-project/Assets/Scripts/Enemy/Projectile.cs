using System;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    [SerializeField] private int damage = 1;

    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        Debug.Log("Start of a projectile");
    }

    protected void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        

        Quaternion dir = Quaternion.FromToRotation(transform.rotation * Vector3.up, Quaternion.identity * Vector3.up);

        transform.rotation = dir;
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, target * 2, speed * Time.deltaTime);
            Destroy(gameObject, 5.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding with something");
        //Destroy(gameObject);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Colliding with player");
            Destroy(gameObject);

            //DestroyProjectile();
            //player.GetComponent<Player> Deal Damage to player
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
