using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMove : MonoBehaviour
{
    //Setting ammo speed
    [SerializeField] private float m_speed;
    private GameObject m_player;
    private float m_playerSpeed;

    private void Start()
    {
        m_player = GameObject.Find("PlayerFlamand");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerSpeed = p_player.m_speed;
        }
        
        //moving ammo on the vector
        transform.Translate(Vector3.back * (m_playerSpeed + m_speed) * Time.deltaTime);
    }

    //function collide to check when an ammo hit the boss
    private void OnTriggerEnter(Collider p_other)
    {
        //compare tag in unity to be sure this is the boss
        if (p_other.CompareTag("Boss"))
        {
            //destroy ammo on touch
            Destroy(gameObject);
        }
    }
}
