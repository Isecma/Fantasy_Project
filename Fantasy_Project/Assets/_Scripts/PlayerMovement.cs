using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int runSpeed = 2;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator animator;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x, moveInput.y) * runSpeed;
        myRigidbody.velocity = playerVelocity;

        if (moveInput.y > 0)
        {
            animator.SetBool("IsRunningHorizontal", false);
            animator.SetBool("IsRunningUp", true);
        }
        else if (moveInput.y < 0)
        {
            animator.SetBool("IsRunningHorizontal", false);
            animator.SetBool("IsRunningDown", true);
        }
        else if (moveInput.y == 0)
        {
            animator.SetBool("IsRunningUp", false);
            animator.SetBool("IsRunningDown", false);
        }

        if (moveInput.y == 0 && Mathf.Abs(moveInput.x) > 0)
        {
            animator.SetBool("IsRunningHorizontal", true);
        }
        else if (moveInput.x == 0)
        {
            animator.SetBool("IsRunningHorizontal", false);
        }


    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(moveInput.x) > Mathf.Epsilon;

        if (moveInput.y > 0) { return; }
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), 1f);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
