using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEggs : MonoBehaviour
{
    
    [SerializeField] private GameObject m_ammo;
    
    [SerializeField] private Vector3 m_popOffset = Vector3.up;

    [SerializeField] private float m_ammoRemain;
    [SerializeField] private float m_ammoCapacity;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Nombre de munitions restante
        m_ammoRemain = 5;
        // Capacité maximale de munition que le joueur peut contenir
        m_ammoCapacity = 5;
    }

    /// <summary>
    /// Si le joueur a au moins 1 munitions il peut tirer
    /// Sinon rien ne se passe
    /// </summary>
    void Update()
    {
        if (m_ammoRemain > 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(m_ammo, transform.position + m_popOffset, m_ammo.transform.rotation);
                m_ammoRemain -= 1;
            }
        }

        else
        {
            Debug.Log(message:"NO AMMO !!!");
        }
        
    }
    
    /// <summary>
    /// Detection de la collision avec les bonus
    /// Si le joueur n'a pas atteint la limite maximale de munition, il peut les ramasser
    /// Sinon rien ne se passe
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (m_ammoRemain < m_ammoCapacity)
        {
            if (other.CompareTag("Bonus"))
            {
                Destroy(other.gameObject);
                Debug.Log(message:"Bonus");
                m_ammoRemain += 1;
            }
        }

        else
        {
            Debug.Log(message:"Full !");
        }
        
    }
}
