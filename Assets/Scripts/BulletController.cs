using System;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{

    private float moveSpeed = 5f;
    private float damage = 25f;

    GameObject player;
    Collider2D bulletCollider;
    Collider2D playerCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<CapsuleCollider2D>();
        bulletCollider = GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, bulletCollider);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        GameObject collisionObj = collision.gameObject;
        HealthManager hm = collision.GetComponent<HealthManager>();
        Debug.Log(collisionObj.tag);



        if (collisionObj.tag == "Enemy")
        { 
            collision.GetComponent<HealthManager>().RemoveHealth(GetDamage());
            Debug.Log(hm.GetHealth());
        }
    }




    //getters/setters
    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
