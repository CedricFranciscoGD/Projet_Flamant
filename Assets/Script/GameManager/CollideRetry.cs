using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            FindObjectOfType<GameManager>().EndGame();
        }
        
        else if (other.CompareTag("Enemy"))
        {
            //Debug.Log(message:"Enemy");
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}
