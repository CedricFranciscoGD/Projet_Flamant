using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecors : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject m_decors;//rives droite et gauches

    //Spawn Settings
    [SerializeField] private float m_riveGaucheX = 10; //Rive gauche axe X
    [SerializeField] private float m_riveDroiteX = 1; //Rive droite axe X
    [SerializeField] private float m_spawnHeight = 10; //Tous les éléments axe Z
    [SerializeField] private float m_waterSpawnX = 10; //Eau axe X
    
    [SerializeField] private float m_riveSpawnPosZ; //Incrementation Rive axe Z
    [SerializeField] private float m_waterSpawnPosZ; //Incrementation Eau axe Z
    
    [SerializeField] private float m_riveLenghtX; //Longeur axe Z prefab modulaire rive
    [SerializeField] private float m_waterLenghtX; //Longueur axe Z prefab modulaire Eau

    [SerializeField] private int m_maxInstances = 50; //Nombre d'itérations spawns
    private int m_countInstances = 0; //Compteur d'itérations
    
    // Update is called once per frame
    void Update()
    {
        //Itérations spawner
        while (m_countInstances < m_maxInstances)
        {
            GenerateDecors();//Spawn Function
            m_countInstances++;
        }
    }

    void GenerateDecors()
    {
        //Instantiate rive gauche/droite/Eau
        Instantiate(m_decors, new Vector3(m_riveGaucheX, m_spawnHeight, m_riveSpawnPosZ),m_decors.transform.rotation); //Gauche
        Instantiate(m_decors, new Vector3(m_riveDroiteX, m_spawnHeight, m_riveSpawnPosZ),m_decors.transform.rotation); //Droite
        IncrementSpawnZ(); //Axe Z spawn function
    }

    void IncrementSpawnZ()
    {
        //Deplace le spawn sur l'axe Z en fonction de la taille des préfabs d'enviro
        m_riveSpawnPosZ -= m_riveLenghtX; //Rives
        m_waterSpawnPosZ -= m_waterLenghtX; //Eau
    }
}
