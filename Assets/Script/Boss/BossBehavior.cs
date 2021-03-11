using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Random=UnityEngine.Random;

public class BossBehavior : MonoBehaviour
{
    //Moving
    [SerializeField] private float m_speedEnemy;//enemy speed for left and right
    [SerializeField] private float m_forwardEnemy;//enemy speed forwaard
    
    //Limits
    [SerializeField] private float m_leftBand;//left border limit
    [SerializeField] private float m_rightBand;//right border limit
    
    //Behavior
    [SerializeField] public bool m_inFight = true;//bool for fight mode
    [SerializeField] private float m_movementSpeed;//left and right move frequency
    [SerializeField] private float m_minMove;//random min border for unpredictable move
    [SerializeField] private float m_maxMove;//random max border for unpredictable move
    private bool m_moveIsDone = true;
    private float m_randomMove;
    private bool m_leftOrRight = true;//bool for alternating moves
    
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_boss;
    [SerializeField] private float m_fromPlayerOffset;
    private float m_posZ;

    //Update is called once per frame
    void Update()
    {
        //behavior
        if (m_inFight)
        {
            //forward move based on player position
            m_posZ = (Math.Abs(m_player.transform.position.z) + Math.Abs(m_fromPlayerOffset))*-1;
            m_boss.transform.position = new Vector3(transform.position.x, transform.position.y, m_posZ);
            
            //Debug.Log("BOSS "+ m_posZ);
            
            //transform.Translate(Vector3.left * m_forwardEnemy * Time.deltaTime);
            
            //randomize move range
            if (m_moveIsDone == true)
            {
                m_randomMove = Random.Range(m_minMove, m_maxMove);//nouveau tirage de longueur de deplacement lateral
                //Debug.Log(m_randomMove);
                m_moveIsDone = false;//bool to grant next move
            }
            //move to..
            else
            {
                if (m_moveIsDone == false)
                {
                    if (m_leftOrRight)//...left
                    {
                        transform.Translate(Vector3.up * m_speedEnemy * Time.deltaTime);
                        m_randomMove -= m_movementSpeed;
                    }
                    else//...right
                    {
                        transform.Translate(Vector3.down * m_speedEnemy * Time.deltaTime);
                        m_randomMove -= m_movementSpeed;
                    }
                    //randomize move range trigger
                    if (m_randomMove < 0)
                    {
                        m_moveIsDone = true;
                        m_leftOrRight = !m_leftOrRight;
                    }
                }
            }
        }

        // delimite la taille des déplacements
        if(transform.position.x > m_leftBand)//left
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
        }

        if(transform.position.x < m_rightBand)//droite
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }
    }
}