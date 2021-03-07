using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTrees : MonoBehaviour
{
    [SerializeField] GameObject m_tree1;
    [SerializeField] GameObject m_tree2;
    [SerializeField] GameObject m_tree3;

    [SerializeField] private float m_maxSpawnX = 10;
    [SerializeField] private float m_minSpawnX = 1;
    [SerializeField] private float m_spawnHeight = 10;
    
    [SerializeField] private float m_spawnPosZ;
    
    [SerializeField] private float m_spawnSpeedMax = 30;
    [SerializeField] private float m_spawnSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;
    private int m_countInstances = 0;
    private int m_pickTree;
    
    // Update is called once per frame
    void Update()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickTree = Random.Range(1, 4);
            GenerateTree();
            m_countInstances++;
        }
    }

    void GenerateTree()
    {
        if (m_pickTree == 2)
        {
            Instantiate(m_tree2, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree2.transform.rotation);
        }
        else if (m_pickTree < 2)
        {
            Instantiate(m_tree1, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree1.transform.rotation);
        }
        else
        {
            Instantiate(m_tree3, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree3.transform.rotation);
        }
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }

    private void OnTriggerEnter(Collider p_other)
    {
        Destroy(gameObject);
    }
}
