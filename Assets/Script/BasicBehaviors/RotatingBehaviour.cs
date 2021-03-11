using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingBehaviour : MonoBehaviour
{
    
    [SerializeField] private float m_time; //Time elapsed since player dead
    [SerializeField] private float m_lowPos; //Time request to launch game over state
    [SerializeField] private float m_highPos; //Time request to launch game over state
    [SerializeField] private bool m_isUp = true;
    

    public GameObject m_shineEffect;

    private void Start()
    {
        Instantiate(m_shineEffect, transform.position, transform.rotation);
    }

    private void Update()
    {
        m_time += Time.deltaTime;
        transform.Rotate(new Vector3(Time.deltaTime*0,0,1));
        if (m_time < m_lowPos)
        {
            m_isUp = false;
            transform.Translate(new Vector3(Time.deltaTime*0,0,0.01f));
        }
        
        else if (m_time > m_lowPos && m_time < m_highPos)
        {
            m_isUp = true;
            transform.Translate(new Vector3(Time.deltaTime*0,0,-0.01f));
        }
        
        else if (m_time > m_highPos)
        {
            m_time = 0;
        }
    }
}
