using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;
    private float xMoveDirection;
    private float xBoundary = 15f;

    void Start()
    {
        if (transform.position.x > 0)
        {
            xMoveDirection = -1;
        }
        
        else
        {
            xMoveDirection = 1;
            transform.localScale = new Vector3(-1, 1, 1); // game object faces right if spawned in x pos lesser than 0
        }
    }

    protected virtual void Update()
    {
        // ABSTRACTION
        Move();
        DestroyOutOfBound();
    }

    protected void Move()
    {
        transform.position += new Vector3(Time.deltaTime * xMoveDirection * speed, 0, 0);
    }

    protected void DestroyOutOfBound()
    {
        if ((xMoveDirection == 1 && transform.position.x > xBoundary) || (xMoveDirection == -1 && transform.position.x < -xBoundary))
        {
            Destroy(gameObject);
        }
    }
}
