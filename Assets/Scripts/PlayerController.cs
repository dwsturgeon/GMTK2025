using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //vars
    Animator playerAnimator;
    PlayerMovement playerMovement;
    //default movespeed
    float playerMoveSpeed;
    Canvas playerCanvas;
    HealthManager playerHealthManager;
    SpriteRenderer playerRenderer;


    [SerializeField] AudioSource shoot;
    [SerializeField] AudioSource splice;
    [SerializeField] AudioSource dash;


    [SerializeField] GameObject DNA;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMoveSpeed = playerMovement.GetMoveSpeed();
        playerHealthManager = GetComponent<HealthManager>();
        playerRenderer = GetComponent<SpriteRenderer>();


        playerCanvas = GetComponentInChildren<Canvas>();
        playerCanvas.enabled = false;

        

    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if(playerHealthManager.GetHealth() <= 0)
        {
            playerRenderer.enabled = false;
            playerCanvas.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.ResetMoveSpeed();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DNA") && (playerAnimator.GetBool("isSplicingDNA") == true))
        {
            playerMovement.SetMoveSpeed(playerMoveSpeed / 2);
        }
    }

    public void SpliceDNA()
    {
        DNA.GetComponent<DNAFunctions>().RemoveCorruption();
    }


    public void PlayShootAudio()
    {
        shoot.Play();
    }

    public void PlaySpliceAudio()
    {
        splice.Play();
    }

    public void PlayDashAudio()
    {
        dash.Play();
    }
}
