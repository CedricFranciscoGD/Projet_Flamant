using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTrees : MonoBehaviour
{
    //prefab
    [SerializeField] GameObject m_tree1;//tree1
    [SerializeField] GameObject m_tree2;//tree2
    [SerializeField] GameObject m_tree3;//tree3

    //spawns settings
    [SerializeField] private float m_maxSpawnX = 10;//max X
    [SerializeField] private float m_minSpawnX = 1;//min X
    [SerializeField] private float m_spawnHeight = 10;//Height Y
    [SerializeField] private float m_spawnPosZ;//Z position
    
    //spawn rythm settings
    [SerializeField] private float m_spawnSpeedMax = 30;//max spawn speed range 
    [SerializeField] private float m_spawnSpeedMin = 5;//min spawn speed range 
    
    [SerializeField] private int m_maxInstances = 50;//instante spawn limit
    private int m_countInstances = 0;//instantiate count
    private int m_pickTree;//stock var to pick a random prefab
    
    private GameObject m_player;
    private float m_playerZPosition;
    [SerializeField] private int m_distanceRespawnTrigger = 50;//max prefab per pop
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningTrees());
        m_player = GameObject.Find("PlayerFlamand");
    }
    
    private void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerZPosition = p_player.m_posZ;
            if (Math.Abs(m_playerZPosition) > Math.Abs(m_spawnPosZ) - Math.Abs(m_distanceRespawnTrigger))
            {
                StartCoroutine(SpawningTrees());
            }
        }
    }

    IEnumerator SpawningTrees()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickTree = Random.Range(1, 4);//random pick number to pick a random prefab
            GenerateTree();//spawn function
            m_countInstances++;
        }
        yield return new WaitForSeconds(0.1f);
    }

    //spawn tree function
    void GenerateTree()
    {
        if (m_pickTree == 2)//tree2
        {
            Instantiate(m_tree2, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree2.transform.rotation);
        }
        else if (m_pickTree < 2)//tree1
        {
            Instantiate(m_tree1, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree1.transform.rotation);
        }
        else//tree3
        {
            Instantiate(m_tree3, new Vector3(Random.Range(m_minSpawnX, m_maxSpawnX), m_spawnHeight, m_spawnPosZ),m_tree3.transform.rotation);
        }
        IncrementSpawnZ();//z axis position spawn increment function
    }

    //z axis position spawn increment function
    void IncrementSpawnZ()
    {
        m_spawnPosZ -= Random.Range(m_spawnSpeedMin, m_spawnSpeedMax);
    }

    //kill on collide to avoird overlappinbg in scene
    private void OnTriggerEnter(Collider p_other)
    {
        Destroy(gameObject);
    }
}
