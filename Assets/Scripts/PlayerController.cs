using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //vars
    Animator playerAnimator;
    PlayerMovement playerMovement;
    //default movespeed
    float playerMoveSpeed;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerMoveSpeed = playerMovement.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.resetMoveSpeed();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DNA") && (playerAnimator.GetBool("isSplicingDNA") == true))
        {
            float newMoveSpeed = playerMoveSpeed / 2;
            playerMovement.SetMoveSpeed(playerMoveSpeed);
        }
    }
}
