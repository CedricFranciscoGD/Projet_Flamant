using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHPmanager : MonoBehaviour
{
    //vars
    [SerializeField] public float m_bossHP;
    [SerializeField] public float m_damageAmmo;

    // Update is called once per frame
    void Update()
    {
        //win function trigger when boss die
        if (m_bossHP <= 0)
        {
            KillBoss();
        }
    }
    
    //Collide function with ammos
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message:"AmmoHit");
        Debug.Log(m_bossHP);
        m_bossHP -= m_damageAmmo;
    }

    //win function for boss kill
    void KillBoss()
    {
        Debug.Log("BossKilled");
    }
}
