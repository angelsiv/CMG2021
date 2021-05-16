using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    [SerializeField] private int damage = 1;

    private int dir = 1;

    [SerializeField] private int lifeCycle = 5;
    
    private void OnEnable()
    {
        StartCoroutine(WaitForDespawnCoroutine());
    }

    private IEnumerator WaitForDespawnCoroutine()
    {
        yield return new WaitForSeconds(lifeCycle);
        Destroy(gameObject);
    }
    
    protected void Update()
    {
        transform.position += (-transform.right*(dir)) * Time.deltaTime * speed;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
