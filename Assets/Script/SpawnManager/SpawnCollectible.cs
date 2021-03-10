using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject m_collect;
    
    //Spawn Settings
    [SerializeField] private float m_maxSpawnX = 10;//max X
    [SerializeField] private float m_minSpawnX = 1;//min X
    [SerializeField] private float m_spawnHeight = 10;//height Y
    
    [SerializeField] private float m_spawnPosZ;//spawn pos in Z axis
    
    //random range for spawn rythm
    [SerializeField] private float m_spawnSpeedMax = 30;//spawn speed max range
    [SerializeField] private float m_spawnSpeedMin = 5;//spawn speed min range
    
    [SerializeField] private int m_maxInstances = 50;//instantiate max limit
    private int m_countInstances = 0;//instantiate count
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningCollectibles());
    }

    IEnumerator SpawningCollectibles()
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
        Instantiate(m_collect, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_collect.transform.rotation);
        IncrementSpawnZ();//z increment spawn function
    }
    //collide to avoid overlapping in scene
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Collider p_else))
        {
            Destroy(gameObject);
            Debug.Log("Overlap, gameobject destroyed");
        }
    }

    //z axis increment spawn function
    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }
}