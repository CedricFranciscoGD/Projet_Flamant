using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEggs : MonoBehaviour
{
    
    [SerializeField] private GameObject m_ammo;
    
    [SerializeField] private Vector3 m_popOffset = Vector3.up;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(m_ammo, transform.position + m_popOffset, m_ammo.transform.rotation);
        }
    }
}
