using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
        }

    }
}
