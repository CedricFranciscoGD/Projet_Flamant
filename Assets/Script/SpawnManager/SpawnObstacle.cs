﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random=UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    
    [SerializeField] GameObject m_obstacle;

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
            GenerateObstacle();
            m_countInstances++;
        }
    }

    void GenerateObstacle()
    {
        Instantiate(m_obstacle, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_obstacle.transform.rotation);
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
}