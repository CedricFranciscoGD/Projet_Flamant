using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    [SerializeField] private float m_delay;
    [SerializeField] private float m_elapsedTime;
    [SerializeField] GameObject m_collect;
    CharaController m_caraCtrl;
    private Rigidbody m_rb;

    [Tooltip("Spawn collectible distance")]
    [SerializeField] private float m_dist = 10;

        
    void Start()
    {
        m_elapsedTime = 0;
        GameObject player = GameObject.Find("Player");
        m_caraCtrl = player.GetComponent<CharaController>();
        m_rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime+= Time.deltaTime;

        if (m_elapsedTime >= m_delay)
        {
            GenerateCollectible();
            m_elapsedTime = 0;
        }
            
    }

    void GenerateCollectible()
    {
        Instantiate(m_collect, m_rb.transform.position + m_rb.transform.right * m_dist, m_collect.transform.rotation);
    }
}