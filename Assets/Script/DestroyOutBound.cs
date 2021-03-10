using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Transform p_else))
        {
            Destroy(p_other.gameObject);
        }
        
        if (p_other.TryGetComponent(out MeshRenderer p_else1))
        {
            Destroy(p_other.gameObject);
        }
    }
}
