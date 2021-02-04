using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Enemy"))
        {
            
            Destroy(p_other.gameObject);
            Destroy(gameObject);
            print("OK");
        }
    }
}
