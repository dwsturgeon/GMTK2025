using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool canCutDNA = false;

    void Start()
    {
        
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
        if (collision.CompareTag("DNA"))
        {
            canCutDNA = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DNA"))
        {
            canCutDNA = false;
        }
    }
}
