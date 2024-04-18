using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float speed = 10f;
    float yTopBoundary = -1, yBotBoundary = -8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHook();
        ConstrainHook();
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
        if (other.CompareTag("Shark"))
        {
            Debug.Log("Player is eaten by a shark...");
        }
        else if (other.CompareTag("Fish"))
        {
            Debug.Log("Player caught a fish!");
        }
        else if (other.CompareTag("Treasure"))
        {
            Debug.Log("Player found a treasure!");
        }
        else if (other.CompareTag("Garbage"))
        {
            Debug.Log("Player collected a garbage.");
        }
    }
}
