using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random=UnityEngine.Random;

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
    [SerializeField] private bool m_inFight = true;
    [SerializeField] private bool m_leftOrRight = true;
    [SerializeField] private float m_movmentSpeed;
    private float m_randomMove;
    [SerializeField] private float m_minMove;
    [SerializeField] private float m_maxMove;
    private bool m_moveIsDone = true;
    
    
    //Update is called once per frame
    void Update()
    {
        //behavior
        if (m_inFight)
        {
            transform.Translate(Vector3.back * m_forwardEnemy * Time.deltaTime);

            if (m_moveIsDone == true)
            {
                m_randomMove = Random.Range(m_minMove, m_maxMove);
                //Debug.Log(m_randomMove);
                m_moveIsDone = false;
            }
            else
            {
                if (m_moveIsDone == false)
                {
                    if (m_leftOrRight)
                    {
                        transform.Translate(Vector3.right * m_speedEnemy * Time.deltaTime);
                        m_randomMove -= m_movmentSpeed;
                    }
                    else
                    {
                        transform.Translate(Vector3.left * m_speedEnemy * Time.deltaTime);
                        m_randomMove -= m_movmentSpeed;
                    }

                    if (m_randomMove < 0)
                    {
                        m_moveIsDone = true;
                        m_leftOrRight = !m_leftOrRight;
                    }
                }
            }
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