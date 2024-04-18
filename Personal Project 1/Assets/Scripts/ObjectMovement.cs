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

    void Update()
    {
        transform.Translate(Time.deltaTime * xMoveDirection * speed, 0, 0);
        if ( (xMoveDirection == 1 && transform.position.x > xBoundary) || (xMoveDirection == -1 && transform.position.x < -xBoundary) )
        {
            Destroy(gameObject);
        }
    }
}
