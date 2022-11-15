using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int runSpeed = 2;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x, moveInput.y) * runSpeed;
        myRigidbody.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
