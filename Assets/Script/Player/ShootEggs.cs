using System;
using UnityEngine;
using UnityEngine.UI;

public class ShootEggs : MonoBehaviour
{
    
    [SerializeField] private GameObject m_ammo;//gameobject prefab
    [SerializeField] private Vector3 m_popOffset = Vector3.up;//offset player shoot ammo setting

    [SerializeField] private float m_ammoRemain;//remaining ammos 
    [SerializeField] private float m_ammoCapacity;//max player ammo capacity

    public Text m_ammoDisplay;//UI

    public AudioSource Shoot;

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
        // AmmoDisplay reacts from player shooting
        m_ammoDisplay.text = m_ammoRemain.ToString();
        if (m_ammoRemain > 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                
                PlayShoot();
            }
        }

        else
        {
            //Debug.Log(message:"NO AMMO !!!");
        }
        
    }
    
    /// <summary>
    /// Detection de la collision avec les bonus
    /// Si le joueur n'a pas atteint la limite maximale de munition, il peut les ramasser
    /// Sinon rien ne se passe
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider p_other)
    {
        if (m_ammoRemain < m_ammoCapacity)
        {
            if (p_other.CompareTag("Bonus"))
            {
                Destroy(p_other.gameObject);
                //Debug.Log(message:"Bonus");
                m_ammoRemain += 1;
            }
        }

        if (m_ammoRemain < m_ammoCapacity)
        {
            if (p_other.CompareTag("Particule"))
            {
                Destroy(p_other.gameObject);
            }
        }

        else
        {
            //Debug.Log(message:"Full !");
        }
        
    }

    public void PlayShoot()
    {
        Shoot.Play();
        Instantiate(m_ammo, transform.position + m_popOffset, m_ammo.transform.rotation);
        m_ammoRemain -= 1;
    }
}
