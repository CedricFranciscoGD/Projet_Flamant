using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsSpawn : MonoBehaviour
{
    [SerializeField] GameObject m_onWater1;
    [SerializeField] GameObject m_onWater2;
    [SerializeField] GameObject m_onGround1;

    [SerializeField] private float m_maxWaterSpawnX = 10;
    [SerializeField] private float m_minWaterSpawnX = 1;

    [SerializeField] private float m_maxGroundSpawnX = 10;
    [SerializeField] private float m_minGroundSpawnX = 1;
    [SerializeField] private float m_groundSpawnHeight = 10;
    [SerializeField] private float m_waterSpawnHeight = 10;
    
    [SerializeField] private float m_spawnWaterPosZ;
    [SerializeField] private float m_spawnGroundPosZ;
    
    [SerializeField] private float m_spawnWaterSpeedMax = 30;
    [SerializeField] private float m_spawnWaterSpeedMin = 5;
    
    [SerializeField] private float m_spawnGroundSpeedMax = 30;
    [SerializeField] private float m_spawnGroundSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;
    private int m_countInstances = 0;
    private int m_pickWaterPlant;

    // Update is called once per frame
    void Update()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickWaterPlant = Random.Range(1, 3);
            GenerateWaterPlant();
            GenerateGroundPlant();
            IncrementSpawnZ();
        }
    }

    void GenerateWaterPlant()
    {
        if (m_pickWaterPlant < 2)
        {
            Instantiate(m_onWater1, new Vector3(Random.Range(m_minWaterSpawnX, m_maxWaterSpawnX), m_waterSpawnHeight, m_spawnWaterPosZ),m_onWater1.transform.rotation);
        }
        else
        {
            Instantiate(m_onWater2, new Vector3(Random.Range(m_minWaterSpawnX, m_maxWaterSpawnX), m_waterSpawnHeight, m_spawnWaterPosZ),m_onWater2.transform.rotation);
        }
        m_countInstances ++;
    }
    
    void GenerateGroundPlant()
    {
        Instantiate(m_onGround1, new Vector3(Random.Range(m_minGroundSpawnX, m_maxGroundSpawnX), m_groundSpawnHeight, m_spawnGroundPosZ),m_onWater1.transform.rotation);
        m_countInstances ++;
    }

    void IncrementSpawnZ()
    {
        m_spawnWaterPosZ -= Random.Range(m_spawnWaterSpeedMin, m_spawnWaterSpeedMax);
        m_spawnGroundPosZ -= Random.Range(m_spawnGroundSpeedMin, m_spawnGroundSpeedMax);
    }

    private void OnTriggerEnter(Collider p_other)
    {
        Destroy(gameObject);
    }
}
