using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMove : MonoBehaviour
{
    //Setting ammo speed
    [SerializeField] private float m_speed;
    

    // Update is called once per frame
    void Update()
    {
        //moving ammo on the vector
        transform.Translate(Vector3.back * m_speed * Time.deltaTime);   
    }

    //function collide to check when an ammo hit the boss
    private void OnTriggerEnter(Collider p_other)
    {
        //compare tag in unity to be sure this is the boss
        if (p_other.CompareTag("Boss"))
        {
            //destroy ammo on touch
            Destroy(gameObject);
        }
    }
}
