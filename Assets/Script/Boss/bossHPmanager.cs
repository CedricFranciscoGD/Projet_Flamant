using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHpManager : MonoBehaviour
{
    //vars
    [SerializeField] public float m_bossHP;
    [SerializeField] public float m_damageAmmo;

    //* Update is called once per frame
    
    void Update()
    {
        
    }
    
    //Collide function with ammos
    //If boss get hit from player ammos 
    //Lose hp 
    //If Boss HP = 0 boss die and launch win fonction
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShoot"))
            {
                m_bossHP -= m_damageAmmo;
                Debug.Log(message:"AmmoHit");
                Debug.Log(m_bossHP);
            }
    //win function trigger when boss die
        if (m_bossHP <= 0)
            {
                KillBoss();
            }
    }

    //win function for boss kill
    //Launch win menu
    //Game can be restart from this menu
    void KillBoss()
    {
        Debug.Log("BossKilled");
        Destroy(gameObject);
        SceneManager.LoadScene("Win_Menu");
    }
}
