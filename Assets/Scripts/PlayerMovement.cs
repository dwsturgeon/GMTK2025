using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]float moveSpeed = 5f;

    private Vector2 moveInput;
    [SerializeField] private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if(moveInput.x == -1 && sr.flipX == false)
        {
           sr.flipX = true;
        }
        else
        {
            if(moveInput.x == 1 && sr.flipX == true)
            {
                sr.flipX = false;
            }
        }

    }
}
