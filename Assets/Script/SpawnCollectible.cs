﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    [SerializeField] GameObject m_collect;
    
    [SerializeField] private float m_maxSpawnX = 10;
    [SerializeField] private float m_minSpawnX = 1;
    [SerializeField] private float m_spawnHeight = 10;
    
    private float m_spawnPosZ = 100;
    
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
        Instantiate(m_collect, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_collect.transform.rotation);
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
}