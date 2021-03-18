using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour
{
    [SerializeField] public float m_speed; //character speed
    [SerializeField] private float m_leftBand; //left border limit
    [SerializeField] private float m_rightBand; //right border limit

    public bool playerIsDead;

    [SerializeField] private float m_countMax = 115;
    [SerializeField] private float m_countMaxAdd = 100;
    [SerializeField] private float m_countDistance = 0;
    [SerializeField] private float m_increaseSpeed = 1.1f;
    [SerializeField] public float m_posZ;
    [SerializeField] public float m_maxSpeed;

    [SerializeField] private float m_elapsedTime;
    [SerializeField] private float m_delay;

    public bool isDead = false;

    private float m_leftDir = 0.1f;
    private float m_rightDir = 0.1f;
    private float m_angle = 90;

    public AudioSource playerDead;

    // Update is called once per frame
    void Update()
    {
        m_posZ = transform.position.z;
        //Debug.Log("Player " + m_posZ);

        if (!isDead)
        {
            // récupère la valeur de l'axe
            float inputValue = Input.GetAxis("Horizontal");

            // deplace le personnage
            transform.Translate(Vector3.left * m_speed * Time.deltaTime * inputValue);
            //Déplace le personnage automatiquement
            transform.Translate(Vector3.back * m_speed * Time.deltaTime);
        }

        if (isDead)
        {
            m_elapsedTime += Time.deltaTime;

            if (m_elapsedTime >= m_delay)
            {
                SceneManager.LoadScene("Game_Over_Menu");
            }
        }

        // delimite la taille des déplacements
        if (transform.position.x > m_leftBand) //left
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
        }

        if (transform.position.x < m_rightBand) //right
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }

        //SpeedIncrease
        m_countDistance = Math.Abs(transform.position.z);
        if (m_countDistance > m_countMax)
        {
            if (m_speed < m_maxSpeed)
            {
                SpeedIncrease();
            }
            else
            {
                Debug.Log("MaxSpeedReached");
            }
        }
    }

    void SpeedIncrease()
    {
        Debug.Log("________________________speedincrease");
        m_speed = m_speed * m_increaseSpeed;
        m_countMax = m_countMax + m_countMaxAdd;
    }

    /// <summary>
    /// Si le joueur rentre en contact avec un danger, la fonction "EndGame" du GameManager est lancée
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider p_other)
    {
        if (!isDead)
        {
            if (p_other.CompareTag("Danger"))
            {
                playerDead.Play();
                //Debug.Log(message:"Danger");
                isDead = true;
                DeadPos();
            }

            else if (p_other.CompareTag("Enemy"))
            {
                playerDead.Play();
                isDead = true;
                DeadPos();
            }
        }
    }
    
    private void DeadPos()
    {
        transform.Rotate(Vector3.back * m_angle);
        transform.Translate(0, -1, 0);
    }
}


