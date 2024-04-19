using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    
    public float Speed // ENCAPSULATION
    {
        get { return speed; }
    }
    private float speed = 3f;
    float xBoundary = 9;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        MovePlayer();
        ConstrainPlayer();
    }

    // Reads user mouse motion in the x axis to move the player left and right
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * Time.deltaTime * speed, 0, 0);

        // Boat faces right when moving in the right direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Boat faces left when moving left
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // prevents player from going beyond the camera view
    void ConstrainPlayer()
    {
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            gameManager.catchValue += gameManager.fishValue;
            Destroy(other.gameObject);
            gameManager.PlaySound(1);
        }
        else if (other.CompareTag("Treasure"))
        {
            gameManager.catchValue += gameManager.treasureValue;
            Destroy(other.gameObject);
            gameManager.PlaySound(1);
        }
        else if (other.CompareTag("Garbage"))
        {
            gameManager.catchValue += gameManager.garbageValue;
            Destroy(other.gameObject);
            gameManager.PlaySound(2);
        }
    }
}
