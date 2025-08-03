using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float moveSpeed = 3;

    GameObject player;
    GameObject DNA;
    Animator animator;
    HealthManager healthManager;

   

    [SerializeField] AudioSource Attack1;

    [SerializeField] AudioSource Death1;

    void Start()
    {
        animator = GetComponent<Animator>();
        healthManager = GetComponent<HealthManager>();
        player = GameObject.Find("Player");
        DNA = GameObject.Find("DNA");
    }

    private void Awake()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("isDying"))
        {
            MoveTowardsTarget();
        }
    }


    private void FixedUpdate()
    {
        if (healthManager.GetHealth() <= 0)
        {
            animator.SetBool("isDying", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<HealthManager>().RemoveHealth(10);
        }
    }


    private void MoveTowardsTarget()
    {

        
        float playerDistance = Vector2.Distance(transform.position, player.transform.position);
        float DNADistance = Vector2.Distance(transform.position, DNA.transform.position);

        float xPositionBefore = transform.position.x;
        float xPositionAfter;

        /*if (playerDistance < DNADistance)
        {*/
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            
        /*}
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, DNA.transform.position, moveSpeed * Time.deltaTime);
        }*/

        xPositionAfter = transform.position.x;

        if (xPositionBefore > xPositionAfter)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void playDeath()
    {
        Death1.Play();
    }

    public void playAttack()
    {
        Attack1.Play();
    }
}
