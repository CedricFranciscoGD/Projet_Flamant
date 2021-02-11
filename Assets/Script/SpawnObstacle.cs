using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private float m_delay;
    [SerializeField] private float m_elapsedTime;
    [SerializeField] GameObject m_obstacle;
    CharaController m_caraCtrl;
    private Rigidbody m_rb;

    [Tooltip("Spawn distance")]
    [SerializeField] private float m_dist = 10;

    
    void Start()
    {
        m_elapsedTime = 0;
        GameObject player = GameObject.Find("Player");
        m_caraCtrl = player.GetComponent<CharaController>();
        m_rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime+= Time.deltaTime;

        if (m_elapsedTime >= m_delay)
        {
            GenerateObstacle();
            m_elapsedTime = 0;
        }
        
    }

    void GenerateObstacle()
    {
        Instantiate(m_obstacle, m_rb.transform.position + m_rb.transform.right * m_dist, m_obstacle.transform.rotation);
    }

}
