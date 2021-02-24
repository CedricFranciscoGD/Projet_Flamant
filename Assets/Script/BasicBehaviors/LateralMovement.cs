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
    private float m_loopMovement;
    [SerializeField] private float m_elapsedTime = 0f;
    // Update is called once per frame

    private void Start()
    {
        m_loopMovement = Random.Range(1f, 2f);
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
}
