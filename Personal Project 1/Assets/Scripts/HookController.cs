using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float speed = 10f;
    float yTopBoundary = 0.02f, yBotBoundary = -8;
    private GameObject caughtObject;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveHook();
        ConstrainHook();

        if (caughtObject != null)
        {
            caughtObject.transform.position = transform.position;
        }
    }
    // Reads user scroll wheel to lower and raise hook
    void MoveHook()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, verticalInput * Time.deltaTime * speed, 0);
    }

    // Prevents the hook from going beyond the camera view
    void ConstrainHook()
    {
        if (transform.localPosition.y > yTopBoundary)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, yTopBoundary, transform.localPosition.z);
        }
        else if (transform.localPosition.y < yBotBoundary)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, yBotBoundary, transform.localPosition.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( ( other.gameObject.CompareTag("Fish") || other.gameObject.CompareTag("Treasure") || other.gameObject.CompareTag("Garbage") ) && caughtObject == null)
        {
            caughtObject = other.gameObject;
            other.gameObject.transform.Rotate(0, 0, -90);
            other.gameObject.transform.localScale = new Vector3(1, 1, 1);

            gameManager.PlaySound(0);
        }
        if (other.gameObject.CompareTag("Shark"))
        {
            gameManager.PlaySound(3);
            gameManager.EndGame();
        }
    }
}
