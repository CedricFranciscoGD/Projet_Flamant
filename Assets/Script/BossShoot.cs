using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    //Ammo GameObject and offset setting
    [SerializeField] private GameObject m_bossAmmo;
    [SerializeField] private Vector3 m_popOffset = Vector3.left;
    
    //Shootint values
    [SerializeField] private float m_time;
    [SerializeField] public float m_trigger;

    void Update()
    {
        //Timing increment
        m_time += Time.deltaTime;
        //print(m_shootSpeed);
        if (m_time >= m_trigger)
        {
            m_time = 0;
            BossShot();
        }
    }
    
    void BossShot()
    {
        Instantiate(m_bossAmmo, transform.position + m_popOffset, m_bossAmmo.transform.rotation);
    }
}

