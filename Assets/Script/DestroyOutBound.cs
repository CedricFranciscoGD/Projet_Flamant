using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_sensor;
    [SerializeField] private float m_fromPlayerOffset;
    private float m_posZ;

    private void Update()
    {
        //forward move based on player position
        m_posZ = m_player.transform.position.z + Math.Abs(m_fromPlayerOffset);
        m_sensor.transform.position = new Vector3(transform.position.x, transform.position.y, m_posZ);
        
        Debug.Log("Sensor "+ m_posZ);
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.TryGetComponent(out Transform p_else))
        {
            Destroy(p_other.gameObject);
        }
        
        if (p_other.TryGetComponent(out MeshRenderer p_else1))
        {
            Destroy(p_other.gameObject);
        }
        
        if (p_other.CompareTag("Tree"))
        {
            //destroy ammo on touch
            Destroy(p_other.gameObject);
        }
    }
}
