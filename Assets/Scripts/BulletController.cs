using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{

    private float moveSpeed = 5f;
    private Vector2 targetPosition;
    private Vector2 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        Destroy(gameObject, 5f);
    }

    public void SetMoveDirection(Vector2 newMoveDirection)
    {
        moveDirection = newMoveDirection;
    }


}
