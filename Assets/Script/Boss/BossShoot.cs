
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    //Ammo GameObject and offset setting
    [SerializeField] private GameObject m_bossAmmo;//gameobject for ammo boss
    [SerializeField] private Vector3 m_popOffset = Vector3.left;//offset setting for ammo prefab
    
    //Shootint values
    [SerializeField] private float m_time;//time var
    [SerializeField] public float m_trigger;//shoot frequency

    public AudioSource BossShootSound;

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
    
    //shoot function
    void BossShot()
    {
        //instantiate
        Instantiate(m_bossAmmo, transform.position + m_popOffset, m_bossAmmo.transform.rotation);
        BossShootSound.Play();
    }
}

