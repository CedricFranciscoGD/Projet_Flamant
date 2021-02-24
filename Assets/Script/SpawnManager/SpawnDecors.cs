using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecors : MonoBehaviour
{
    [SerializeField] GameObject m_decors;

    [SerializeField] private float m_riveGaucheX = 10;
    [SerializeField] private float m_riveDroiteX = 1;
    [SerializeField] private float m_spawnHeight = 10;
    
    [SerializeField] private float m_spawnPosZ;
    
    [SerializeField] private float m_prefabLenghtX;

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
        Instantiate(m_decors, new Vector3(m_riveGaucheX, m_spawnHeight, m_spawnPosZ),m_decors.transform.rotation);
        Instantiate(m_decors, new Vector3(m_riveDroiteX, m_spawnHeight, m_spawnPosZ),m_decors.transform.rotation);
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        m_spawnPosZ -= m_prefabLenghtX;
    }
}
