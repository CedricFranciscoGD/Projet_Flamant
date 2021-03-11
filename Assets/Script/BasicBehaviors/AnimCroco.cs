using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCroco : MonoBehaviour
{
    [SerializeField] private float m_time; //Time elapsed since player dead
    [SerializeField] private float m_lowPos; //Time request to launch game over state
    [SerializeField] private float m_highPos; //Time request to launch game over state
    [SerializeField] private bool m_isUp = true; 

    [SerializeField] private float m_angle = 1;
    
    private void Update()
    {
        m_time += Time.deltaTime;

        if (m_time < m_lowPos)
        {
            transform.Rotate(Vector3.up * m_angle);
            m_isUp = false;
        }
        
        else if (m_time > m_lowPos && m_time < m_highPos)
        {
            transform.Rotate(Vector3.up * -m_angle);
            m_isUp = true;
        }
        
        else if (m_time > m_highPos)
        {
            m_time = 0;
        }
    }
}
