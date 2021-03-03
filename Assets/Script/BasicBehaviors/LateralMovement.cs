using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random=UnityEngine.Random;

public class LateralMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float m_speedEnemy;

    [SerializeField]
    private float m_leftBand;

    [SerializeField]
    private float m_rightBand;
    private float m_loopMovement; //time reference
    [SerializeField] private float m_elapsedTime = 0f;

    //range setting for a random move lentgh
    [SerializeField] private float m_minMoveRange;
    [SerializeField] private float m_maxMoveRange;

    private void Start()
    {
        m_loopMovement = Random.Range(m_minMoveRange, m_maxMoveRange);
    }

    void Update()
    {

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
    
    //Go back on collide
    private void OnTriggerEnter(Collider p_other)
    {
        if (m_loopMovement < 2)
        {
            m_loopMovement = 2;
        }
        else
        {
            m_loopMovement = 0;
        }
    }
}
