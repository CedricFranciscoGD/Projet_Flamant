﻿
using UnityEngine;

public class CameraFixedOnX : MonoBehaviour
{
    // Position de la Camera en X, Y et Z
    [SerializeField]private float m_fixedOnXAxes = -10;
    [SerializeField]private float m_cameraDistOffsetY = 10;
    [SerializeField]private float m_cameraDistOffsetZ = 10;
    
    private Camera m_mainCamera;
    [SerializeField]private GameObject m_player;
 
    /// <summary>
    /// Récupère la position du joueur
    /// </summary>
    void Start () 
    {
        m_mainCamera = GetComponent<Camera>();
    }
     
    /// <summary>
    /// La caméra suit le joueur sur son axe Y et Z mais elle est bloquée en axe X
    /// </summary>
    void Update () 
    {
        Vector3 playerInfo = m_player.transform.transform.position;
        m_mainCamera.transform.position = new Vector3(m_fixedOnXAxes, playerInfo.y - m_cameraDistOffsetY, playerInfo.z - m_cameraDistOffsetZ);
    }
}
