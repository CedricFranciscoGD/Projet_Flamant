using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //Moving
    [SerializeField] private float m_speedEnemy;
    [SerializeField] private float m_forwardEnemy;
    
    //Limits
    [SerializeField] private float m_leftBand;
    [SerializeField] private float m_rightBand;
    
    //Behavior
    [SerializeField] private float m_loopMovement = 1.0f;
    [SerializeField] private float m_elapsedTime = 0f;
    [SerializeField] private bool m_inFight;
    
    
    // Update is called once per frame
    void Update()
    {
        if (m_inFight)
        {
            transform.Translate(Vector3.back * m_forwardEnemy * Time.deltaTime);
        }
        
        m_elapsedTime = m_loopMovement += Time.deltaTime;
        
        if (m_loopMovement > 0 && m_loopMovement < 2)
        {
            transform.Translate(Vector3.right * m_speedEnemy * Time.deltaTime);
            //print(m_loopMovement);
        }
        
        else if (m_loopMovement >= 2 && m_loopMovement < 4)
        {
            transform.Translate(Vector3.left * m_speedEnemy * Time.deltaTime);
            //print(m_loopMovement);
        }
        
        else if (m_loopMovement >= 4)
        {
            m_loopMovement = 0;
        }
        
        
        // delimite la taille des déplacements
        if(transform.position.x > m_leftBand)
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
        }

        if(transform.position.x < m_rightBand)
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }
    }
}