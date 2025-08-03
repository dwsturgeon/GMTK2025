using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
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
        //FaceCursor();
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

      


        bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0; // Ensure Z-axis is consistent for 2D

        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        
        //bulletInstance.GetComponent<BulletController>().SetDirection(Direction);

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
        ResetMoveSpeed();

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void FaceCursor()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0; // Ensure Z-axis is consistent for 2D

        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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

    public void ResetMoveSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
