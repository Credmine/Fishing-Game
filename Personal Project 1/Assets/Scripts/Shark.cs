using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : ObjectMovement // INHERITANCE
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
        }
    }
}
