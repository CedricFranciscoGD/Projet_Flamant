﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject m_enemy;
    
    [SerializeField] private float m_maxSpawnX = 10;
    [SerializeField] private float m_minSpawnX = 1;
    [SerializeField] private float m_spawnHeight = 10;
    
    [SerializeField] private float m_spawnPosZ;
    
    [SerializeField] private float m_spawnSpeedMax = 30;
    [SerializeField] private float m_spawnSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;
    private int m_countInstances = 0;
    
    // Update is called once per frame
    void Update()
    {
        while (m_countInstances < m_maxInstances)
        {
            GenerateCollectible();
            m_countInstances++;
        }
    }

    void GenerateCollectible()
    {
        Instantiate(m_enemy, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_enemy.transform.rotation);
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Spawnkill(EnemyOverlap)");
        }
        
        if (p_other.CompareTag("Danger"))
        {
            Destroy(gameObject);
            Debug.Log("Spawnkill(ObstacleOverlap)");
        }
    }
}
