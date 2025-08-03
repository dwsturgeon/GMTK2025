using Unity.VisualScripting;
using UnityEngine;

public class DNAFunctions : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float corruption = 500f;
    [SerializeField] float corruptionDMG = 10f;
    [SerializeField] SpriteRenderer corruptionsr;


    private Canvas DNACanvas;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DNACanvas = GetComponentInChildren<Canvas>();
        DNACanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -28)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }

        if(corruption <= 0)
        {
            corruptionsr.enabled = false;
            DNACanvas.enabled = true;
        }
    }

    public void RemoveCorruption()
    {
        corruption -= corruptionDMG;
    }
}
