using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private int dir = 1;
    protected void Update()
    {
        transform.localPosition += (-transform.right*(dir)) * Time.deltaTime * speed;
    }
}
