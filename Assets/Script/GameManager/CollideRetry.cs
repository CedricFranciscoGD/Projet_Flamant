using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideRetry : MonoBehaviour
{
    [SerializeField] private float m_xPos;//position axe X
    [SerializeField] private float m_yPos;//position axe Y
    [SerializeField] private float m_zPos;//position axe Z
    
    
    [SerializeField] private float m_elapsedTime;
    [SerializeField] private float m_delay;

    public AudioSource playerDead;

    public bool isDead = false;


    private void Update()
    {
        if (isDead)
        {
            m_elapsedTime += Time.deltaTime;
            
            if (m_elapsedTime >= m_delay)
            {
                SceneManager.LoadScene("Game_Over_Menu");
            }
            
        }
    }

    /// <summary>
    /// Si le joueur rentre en contact avec un danger, la fonction "EndGame" du GameManager est lancée
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            playerDead.Play();
            //Debug.Log(message:"Danger");
            isDead = true;
        }
        
        else if (other.CompareTag("Enemy"))
        {
            playerDead.Play();
            isDead = true;
        }
        
    }
}
