using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlantsSpawn : MonoBehaviour
{
    //prefab
    [SerializeField] GameObject m_onWater1;//plant in water 1
    [SerializeField] GameObject m_onWater2;//plant in water 2
    [SerializeField] GameObject m_onWater3;//plant in water 2
    [SerializeField] GameObject m_onGround1;//plant on ground 1
    [SerializeField] GameObject m_onGround2;//plant on ground 2
    [SerializeField] GameObject m_onGround3;//plant on ground 3

    //plant in water spawn border
    [SerializeField] private float m_maxWaterSpawnX = 10;//max
    [SerializeField] private float m_minWaterSpawnX = 1;//min

    //plant on ground spawn border
    [SerializeField] private float m_maxGroundSpawnX = 10;//max
    [SerializeField] private float m_minGroundSpawnX = 1;//min
    
    //plants spawn heights
    [SerializeField] private float m_groundSpawnHeight = 10;//on ground
    [SerializeField] private float m_waterSpawnHeight = 10;//in water
    
    //Zaxis setting 
    [SerializeField] private float m_spawnWaterPosZ;//for water
    [SerializeField] private float m_spawnGroundPosZ;//for ground
    
    //spawn speed water plants
    [SerializeField] private float m_spawnWaterSpeedMax = 30;//max
    [SerializeField] private float m_spawnWaterSpeedMin = 5;//min
    
    //spawn speed ground plants
    [SerializeField] private float m_spawnGroundSpeedMax = 30;
    [SerializeField] private float m_spawnGroundSpeedMin = 5;
    
    [SerializeField] private int m_maxInstances = 50;//max instantiates to limit pop
    private int m_countInstances = 0;//instantiate count
    private int m_pickWaterPlant;//var to stock the random pick in water prefabs
    private int m_pickGroundPlant;//var to stock the random pick in water prefabs
    
    private GameObject m_player;
    private float m_playerZPosition;
    [SerializeField] private int m_distanceRespawnTrigger = 50;//max prefab per pop

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningPlants());
        m_player = GameObject.Find("PlayerFlamand");
    }
    
    private void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerZPosition = p_player.m_posZ;
            if (Math.Abs(m_playerZPosition) > Math.Abs(m_spawnWaterPosZ) - Math.Abs(m_distanceRespawnTrigger))
            {
                StartCoroutine(SpawningPlants());
            }
        }
    }

    IEnumerator SpawningPlants()
    {
        while (m_countInstances < m_maxInstances)
        {
            m_pickWaterPlant = Random.Range(1, 4);
            m_pickGroundPlant = Random.Range(1, 4);
            GenerateWaterPlant();//water plant spawns
            GenerateGroundPlant();//ground plant spawns
            IncrementSpawnZ();//Z positions spawn increment
        }
        yield return new WaitForSeconds(0.1f);
    }
    
    //water plants pop function
    void GenerateWaterPlant()
    {
        if (m_pickWaterPlant > 1)
        {
            Instantiate(m_onWater1, new Vector3(Random.Range(m_minWaterSpawnX, m_maxWaterSpawnX), m_waterSpawnHeight, m_spawnWaterPosZ),m_onWater1.transform.rotation);
        }
        else if (m_pickWaterPlant < 3 && m_pickWaterPlant < 1)
        {
            Instantiate(m_onWater2, new Vector3(Random.Range(m_minWaterSpawnX, m_maxWaterSpawnX), m_waterSpawnHeight, m_spawnWaterPosZ),m_onWater2.transform.rotation);
        }
        else
        {
            Instantiate(m_onWater3, new Vector3(Random.Range(m_minWaterSpawnX, m_maxWaterSpawnX), m_waterSpawnHeight, m_spawnWaterPosZ),m_onWater3.transform.rotation);
        }
        
        m_countInstances ++;
    }
    
    //ground plant pop function
    void GenerateGroundPlant()
    {
        if (m_pickGroundPlant < 2)
        {
            Instantiate(m_onGround1, new Vector3(Random.Range(m_minGroundSpawnX, m_maxGroundSpawnX), m_groundSpawnHeight, m_spawnGroundPosZ),m_onWater1.transform.rotation);
        }
        else if (m_pickGroundPlant < 3 && m_pickGroundPlant < 1)
        {
            Instantiate(m_onGround2, new Vector3(Random.Range(m_minGroundSpawnX, m_maxGroundSpawnX), m_groundSpawnHeight, m_spawnGroundPosZ),m_onWater2.transform.rotation);
        }
        else
        {
            Instantiate(m_onGround3, new Vector3(Random.Range(m_minGroundSpawnX, m_maxGroundSpawnX), m_groundSpawnHeight, m_spawnGroundPosZ),m_onWater3.transform.rotation);
        }
        
        m_countInstances ++;
    }

    //Z axis spawn increment 
    void IncrementSpawnZ()
    {
        m_spawnWaterPosZ -= Random.Range(m_spawnWaterSpeedMin, m_spawnWaterSpeedMax);//water plants
        m_spawnGroundPosZ -= Random.Range(m_spawnGroundSpeedMin, m_spawnGroundSpeedMax);//ground plants
    }

    //kill on collide to avoid overlaping in scene
    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Collider p_else))
        {
            Destroy(gameObject);
            Debug.Log("Overlap, gameobject destroyed");
        }
    }
}
