﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemynotmovingSpawn : MonoBehaviour
{
    //Game Objects
    [SerializeField] GameObject m_enemy;
    
    //Spawn Settings
    [SerializeField] private float m_maxSpawnX = 10; //Maximum axe X
    [SerializeField] private float m_minSpawnX = 1; //Minimum axe X
    [SerializeField] private float m_spawnHeight = 10; //Hauteur axe Y
    [SerializeField] private float m_spawnPosZ; //Position axe Z

    //Random range for spawn speed
    [SerializeField] private float m_spawnSpeedMax = 30;//max border spawn range speed
    [SerializeField] private float m_spawnSpeedMin = 5;//min border spawn range speed
    
    //Itérations spawns
    [SerializeField] private int m_maxInstances = 50;//max prefab per pop
    private int m_countInstances = 0;//instantiate count
    
    private GameObject m_player;
    private float m_playerZPosition;
    [SerializeField] private int m_distanceRespawnTrigger = 50;//max prefab per pop
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningEnemies());
        m_player = GameObject.Find("PlayerFlamand");
        //Debug.Log(m_spawnPosZ);
    }

    private void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerZPosition = p_player.m_posZ;
            if (Math.Abs(m_playerZPosition) > Math.Abs(m_spawnPosZ) - Math.Abs(m_distanceRespawnTrigger))
            {
                StartCoroutine(SpawningEnemies());
            }
        }
    }

    IEnumerator SpawningEnemies()
    {
        //Itérations spawner
        while (m_countInstances < m_maxInstances)
        {
            GenerateEnemy();//Spawn Function
            m_countInstances++;
        }
        yield return new WaitForSeconds(0.1f);
    }

    void GenerateEnemy()
    {
        //Instantiate Enemy spawn
        Instantiate(m_enemy, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_enemy.transform.rotation);
        IncrementSpawnZ();//moving spawn on Z function
    }

    void IncrementSpawnZ()
    {
        //Deplace le spawn sur l'axe Z
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
    
    //kill on collide to avoid overlapping object in scene
    
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Collider p_else))
        {
            Destroy(p_other.gameObject);
            Debug.Log("Overlap, gameobject destroyed");
        }
    }
    
}
