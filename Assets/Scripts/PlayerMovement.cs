using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LightTransport;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]float moveSpeed = 5f;
    private float defaultMoveSpeed;

    private Vector2 moveInput;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private GameObject bullet;

    //for customizations without affecting original prefab
    private GameObject bulletInstance;

    private Animator playerAnimator;


    //dashing
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private bool canDash = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        defaultMoveSpeed = moveSpeed;
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

    public void splice(InputAction.CallbackContext context)
    {
        if (playerAnimator.GetBool("isSplicingDNA"))
        {
            playerAnimator.SetBool("isSplicingDNA", false);
        }
        else
        {
            playerAnimator.SetBool("isSplicingDNA", true);
        }
            
    }


    //on left click
    public void Fire(InputAction.CallbackContext context)
    {
        //Vector2 cursorPosition = context.ReadValue<Vector2>();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 playerPosition = transform.position;


        bulletInstance = Instantiate(bullet, playerPosition, transform.rotation);


        //Debug.Log("fire");
    }


    //dash - left shift

    public void Dash(InputAction.CallbackContext context)
    {
        if (!playerAnimator.GetBool("isSplicingDNA"))
        {
            StartCoroutine(DashRoutine());
        }
    }
    IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;

        moveSpeed = moveSpeed * dashSpeed;
        playerAnimator.SetBool("isDashing", true);

        yield return new WaitForSeconds(dashTime);

        isDashing = false;
        playerAnimator.SetBool("isDashing", false);
        resetMoveSpeed();

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }


    // get/set

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void resetMoveSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
