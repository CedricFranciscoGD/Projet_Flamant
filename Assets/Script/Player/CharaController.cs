using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField] private float m_speed;//character speed
    [SerializeField] private float m_leftBand;//left border limit
    [SerializeField] private float m_rightBand;//right border limit

    public bool playerIsDead;

    [SerializeField] private float m_countMax = 115;
    [SerializeField] private float m_countMaxAdd = 100;
    [SerializeField] private float m_countDistance = 0;
    [SerializeField] private float m_increaseSpeed = 1.1f;
    [SerializeField] private float m_posZ;
    
    private void Start()
    {
        playerIsDead = GetComponent<CollideRetry>().isDead;
    }


    // Update is called once per frame
    void Update()
    {
        m_posZ = transform.position.z;
        Debug.Log("Player "+ m_posZ);
        // récupère la valeur de l'axe
        float inputValue = Input.GetAxis("Horizontal");

        // deplace le personnage
        transform.Translate(Vector3.left * m_speed * Time.deltaTime * inputValue);
        //Déplace le personnage automatiquement
        transform.Translate(Vector3.back * m_speed * Time.deltaTime);

        // delimite la taille des déplacements
        if(transform.position.x > m_leftBand)//left
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
        }

        if(transform.position.x < m_rightBand)//right
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }

        if (playerIsDead)
        {
            m_speed = 0;
        }
        
        //SpeedIncrease
        m_countDistance = Math.Abs(transform.position.z);
        if (m_countDistance > m_countMax)
        {
            SpeedIncrease();
        }
    }

    void SpeedIncrease()
    {
        m_speed = m_speed * m_increaseSpeed;
        m_countMax = m_countMax + m_countMaxAdd;
    }
}


