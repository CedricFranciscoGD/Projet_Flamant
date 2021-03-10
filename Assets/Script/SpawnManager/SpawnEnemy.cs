using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject m_enemy;//enemy prefab
    
    //spawn settings
    [SerializeField] private float m_maxSpawnX = 10;//max border limit
    [SerializeField] private float m_minSpawnX = 1;//min border limit
    [SerializeField] private float m_spawnHeight = 10;//Height spawn position in Y axis
    
    [SerializeField] private float m_spawnPosZ;//z axis position spawn
    
    //random range for spawn rythm
    [SerializeField] private float m_spawnSpeedMax = 30;
    [SerializeField] private float m_spawnSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;//instantiate number limit
    private int m_countInstances = 0;//instantiate count
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        while (m_countInstances < m_maxInstances)
        {
            GenerateCollectible();//spawn function
            m_countInstances++;
        }
        yield return new WaitForSeconds(0.1f);
    }

    //spawn function
    void GenerateCollectible()
    {
        Instantiate(m_enemy, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_enemy.transform.rotation);
        IncrementSpawnZ();//z axis spawn increment function
    }

    //z axis spawn increment function
    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }

    //kill on collide to avoid overlapping objects in scene
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Collider p_else))
        {
            Destroy(p_other.gameObject);
            Debug.Log("Overlap, gameobject destroyed");
        }
    }
}
