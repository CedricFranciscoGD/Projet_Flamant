using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float m_bossHP;
    public float m_damageAmmo;
    public Slider m_slider;
    
    public void SetHealth(float m_bossHP)
    {
        m_slider.value = m_bossHP;
    }
   
    // Update is called once per frame
    void Update()
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerShoot"))
            {
                m_bossHP -= m_damageAmmo;
                Debug.Log(message:"AmmoHit");
                Debug.Log(m_bossHP);
            }
            
        }
    }
}
