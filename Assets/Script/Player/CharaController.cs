using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour
{
    [SerializeField] private float m_speed;//character speed
    [SerializeField] private float m_leftBand;//left border limit
    [SerializeField] private float m_rightBand;//right border limit
    
    
    [SerializeField] private float m_xPos;//position axe X
    [SerializeField] private float m_yPos;//position axe Y
    [SerializeField] private float m_zPos;//position axe Z
    
    
    [SerializeField] private float m_elapsedTime; //Time elapsed since player dead
    [SerializeField] private float m_delay; //Time request to launch game over state

    public AudioSource playerDead; //Dead sound

    public bool isDead = false; //State player

    
    private float m_angle = 90;     //Rotate to lie down

    // Update is called once per frame
    void Update()
    {
        //if player isn't dead, he can move
        if (!isDead)
        {
            // récupère la valeur de l'axe
            float inputValue = Input.GetAxis("Horizontal");

            // deplace le personnage
            transform.Translate(Vector3.left * m_speed * Time.deltaTime * inputValue);
            //Déplace le personnage automatiquement
            transform.Translate(Vector3.back * m_speed * Time.deltaTime);
        }
        

        //When boolean isDead is set to true, launch a timer to let anim and sound play, then game over is launched
        if (isDead)
        {
            m_elapsedTime += Time.deltaTime;
            
            if (m_elapsedTime >= m_delay)
            {
                SceneManager.LoadScene("Game_Over_Menu");
            }
            
        }
        
        // delimite la taille des déplacements
        if(transform.position.x > m_leftBand)//left
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);

        }

        if(transform.position.x < m_rightBand)//right
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }
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

    //When player die, his position rotate 
    private void DeadPos()
    {
        transform.Rotate(Vector3.back * m_angle);
        transform.Translate(0,-1,0);
    }
}

