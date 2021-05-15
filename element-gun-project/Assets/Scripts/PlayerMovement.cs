using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] private Rigidbody2D playerRigidbody;

    private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void OnMove()
    {
        playerRigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //foreach (Transform child in transform)
        //{
        //    child.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //}
    }
}
