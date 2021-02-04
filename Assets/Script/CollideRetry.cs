using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideRetry : MonoBehaviour
{
    [SerializeField] private float m_xPos;
    [SerializeField] private float m_yPos;
    [SerializeField] private float m_zPos;
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(m_xPos, m_yPos, m_zPos);
    }
}
