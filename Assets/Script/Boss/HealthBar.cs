
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float m_bossHP;//boss HP pool
    public float m_damageAmmo;//boss ammo damage to player
    public Slider m_slider;//slider for health in UI
    
    public void SetHealth(float m_bossHP)
    {
        m_slider.value = m_bossHP;
    }
   
    // Update is called once per frame
    
    // If boss get hit from player ammo
    // Boss loose life and show it on his UI health bar
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerShoot"))
            {
                m_slider.value -= m_damageAmmo;
            }
        }
}
