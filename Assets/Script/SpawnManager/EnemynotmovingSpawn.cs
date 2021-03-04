using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private float m_spawnSpeedMax = 30;
    [SerializeField] private float m_spawnSpeedMin = 5;
    
    //Itérations spawns
    [SerializeField] private int m_maxInstances = 50;
    private int m_countInstances = 0;
    
    // Update is called once per frame
    void Update()
    {
        //Itérations spawner
        while (m_countInstances < m_maxInstances)
        {
            GenerateEnemy();//Spawn Function
            m_countInstances++;
        }
    }

    void GenerateEnemy()
    {
        //Instantiate Enemy spawn
        Instantiate(m_enemy, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_enemy.transform.rotation);
        IncrementSpawnZ();
    }

    void IncrementSpawnZ()
    {
        //Deplace le spawn sur l'axe Z
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
