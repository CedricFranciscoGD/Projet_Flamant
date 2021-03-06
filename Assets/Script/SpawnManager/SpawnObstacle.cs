using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random=UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    
    [SerializeField] GameObject m_rockObstacle1;
    [SerializeField] GameObject m_rockObstacle2;
    [SerializeField] GameObject m_rockObstacle3;

    [SerializeField] private float m_maxSpawnX = 10;
    [SerializeField] private float m_minSpawnX = 1;
    [SerializeField] private float m_spawnHeight = 10;
    
    [SerializeField] private float m_spawnPosZ;
    
    [SerializeField] private float m_spawnSpeedMax = 30;
    [SerializeField] private float m_spawnSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;
    private int m_countInstances = 0;
    private int m_pickRock = 0;
    
    // Update is called once per frame
    void Update()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickRock = Random.Range(1, 4);
            GenerateObstacle();
            m_countInstances++;
        }
    }

    void GenerateObstacle()
    { 
        if (m_pickRock == 2)
        {
            Instantiate(m_rockObstacle1, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle1.transform.rotation);
        }
        else if (m_pickRock < 2)
        {
            Instantiate(m_rockObstacle2, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle2.transform.rotation);
        }
        else
        {
            Instantiate(m_rockObstacle3, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle3.transform.rotation);
        }
        IncrementSpawnZ();
    }
    
    private void OnTriggerEnter(Collider p_other)
    {
        Destroy(gameObject);
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
}
