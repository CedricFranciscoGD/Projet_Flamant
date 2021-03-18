using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DepopAmmo());
    }

    IEnumerator DepopAmmo()
    
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
