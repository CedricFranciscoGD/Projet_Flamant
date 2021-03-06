﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random=UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    //prefabs
    [SerializeField] GameObject m_rockObstacle1;//rock1
    [SerializeField] GameObject m_rockObstacle2;//rock2
    [SerializeField] GameObject m_rockObstacle3;//rock3

    //sapwn settings limits
    [SerializeField] private float m_maxSpawnX = 10;//max X
    [SerializeField] private float m_minSpawnX = 1;//min X
    [SerializeField] private float m_spawnHeight = 10;//Y height
    [SerializeField] private float m_spawnPosZ;//Z spawn position increment
    
    //spawn rythm
    [SerializeField] private float m_spawnSpeedMax = 30;//spawn speed range max
    [SerializeField] private float m_spawnSpeedMin = 5;//spawn speed range min
    
    [SerializeField] private int m_maxInstances = 50;//instantiate spawn limit
    private int m_countInstances = 0;//instantiate count
    private int m_pickRock = 0;//stock var for pick rocks
    
    private GameObject m_player;
    private float m_playerZPosition;
    [SerializeField] private int m_distanceRespawnTrigger = 50;//max prefab per pop
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningRocks());
        m_player = GameObject.Find("PlayerFlamand");
    }
    
    private void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerZPosition = p_player.m_posZ;
            if (Math.Abs(m_playerZPosition) > Math.Abs(m_spawnPosZ) - Math.Abs(m_distanceRespawnTrigger))
            {
                StartCoroutine(SpawningRocks());
            }
        }
    }

    IEnumerator SpawningRocks()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickRock = Random.Range(1, 4);//picking a number to get a random prefab
            GenerateObstacle();//spawn function
            m_countInstances++;
        }
        yield return new WaitForSeconds(0.1f);
    }

    //spawn function
    void GenerateObstacle()
    { 
        if (m_pickRock == 2)//rock1 spawn
        {
            Instantiate(m_rockObstacle1, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle1.transform.rotation);
        }
        else if (m_pickRock < 2)//rock2 spawn
        {
            Instantiate(m_rockObstacle2, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle2.transform.rotation);
        }
        else//rock3 spawn
        {
            Instantiate(m_rockObstacle3, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_rockObstacle3.transform.rotation);
        }
        IncrementSpawnZ();//z axis spawn increment function
    }

    //z axis spawn increment function
    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
    
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Collider p_else))
        {
            Destroy(gameObject);
            Debug.Log("Overlap, gameobject destroyed");
        }
    }
}
