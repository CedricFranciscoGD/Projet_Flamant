using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMove : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * m_speed * Time.deltaTime);   
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
