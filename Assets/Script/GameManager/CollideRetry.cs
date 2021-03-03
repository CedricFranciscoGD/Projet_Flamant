using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideRetry : MonoBehaviour
{
    [SerializeField] private float m_xPos;
    [SerializeField] private float m_yPos;
    [SerializeField] private float m_zPos;
    

    /// <summary>
    /// Si le joueur rentre en contact avec un danger, la fonction "EndGame" du GameManager est lancée
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            //Debug.Log(message:"Danger");
            SceneManager.LoadScene("Level_1");
        }
        
        else if (other.CompareTag("Enemy"))
        {
            //Debug.Log(message:"Enemy");
            SceneManager.LoadScene("Level_1");
        }
        
    }
}
