﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecors : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject m_decors;//rives droite et gauches
    [SerializeField] GameObject m_water;//Rivière

    //Spawn Settings
    [SerializeField] private float m_riveGaucheX = 10; //Rive gauche axe X
    [SerializeField] private float m_riveDroiteX = 1; //Rive droite axe X
    [SerializeField] private float m_spawnHeight = 10; //Tous les éléments axe Z
    
    [SerializeField] private float m_waterSpawnX = 10; //Eau axe X
    [SerializeField] private float m_waterSpawnY = 10; //Eau axe y
    
    [SerializeField] private float m_riveSpawnPosZ; //Incrementation Rive axe Z
    [SerializeField] private float m_waterSpawnPosZ; //Incrementation Eau axe Z
    
    [SerializeField] private float m_riveLenghtX; //Longeur axe Z prefab modulaire rive
    [SerializeField] private float m_waterLenghtX; //Longueur axe Z prefab modulaire Eau

    [SerializeField] private int m_maxInstances = 50; //Nombre d'itérations spawns
    private int m_countInstances = 0; //Compteur d'itérations
    
    private GameObject m_player;
    private float m_playerZPosition;
    [SerializeField] private int m_distanceRespawnTrigger = 50;//max prefab per pop
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawningDecors());
        m_player = GameObject.Find("PlayerFlamand");
    }
    
    private void Update()
    {
        if (m_player.TryGetComponent(out CharaController p_player))
        {
            m_playerZPosition = p_player.m_posZ;
            if (Math.Abs(m_playerZPosition) > Math.Abs(m_riveSpawnPosZ) - Math.Abs(m_distanceRespawnTrigger))
            {
                StartCoroutine(SpawningDecors());
            }
        }
    }

    IEnumerator SpawningDecors()
    {
        //Itérations spawner
        while (m_countInstances < m_maxInstances)
        {
            GenerateDecors();//Spawn Function
            m_countInstances++;
        }
        yield return new WaitForSeconds(0.1f);
    }

    void GenerateDecors()
    {
        //Instantiate rive gauche/droite/Eau
        Instantiate(m_decors, new Vector3(m_riveGaucheX, m_spawnHeight, m_riveSpawnPosZ),m_decors.transform.rotation); //Gauche
        Instantiate(m_decors, new Vector3(m_riveDroiteX, m_spawnHeight, m_riveSpawnPosZ),m_decors.transform.rotation); //Droite
        Instantiate(m_water, new Vector3(m_waterSpawnX, m_waterSpawnY, m_waterSpawnPosZ),m_water.transform.rotation); //Rivière
        IncrementSpawnZ(); //Axe Z spawn function
    }

    void IncrementSpawnZ()
    {
        //Deplace le spawn sur l'axe Z en fonction de la taille des préfabs d'enviro
        m_riveSpawnPosZ -= m_riveLenghtX; //Rives
        m_waterSpawnPosZ -= m_waterLenghtX; //Eau
    }
}
