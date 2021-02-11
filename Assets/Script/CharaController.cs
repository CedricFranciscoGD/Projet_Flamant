using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    [SerializeField]
    private float m_leftBand;

    [SerializeField]
    private float m_rightBand;
    

    // Update is called once per frame
    void Update()
    {
        // récupère la valeur de l'axe
        float inputValue = Input.GetAxis("Horizontal");

        // deplace le personnage
        transform.Translate(Vector3.back * m_speed * Time.deltaTime * inputValue);
        //Déplace le personnage automatiquement
        transform.Translate(Vector3.right * m_speed * Time.deltaTime);

        // delimite la taille des déplacements
        if(transform.position.x > m_leftBand){
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
        }

        if(transform.position.x < m_rightBand){
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }
    }
}
