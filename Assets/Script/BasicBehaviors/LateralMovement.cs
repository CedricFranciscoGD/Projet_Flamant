
using UnityEngine;
using Random=UnityEngine.Random;

public class LateralMovement : MonoBehaviour
{
    //setting enemy movement speed
    [SerializeField] private float m_speedEnemy;
    //border for moving enemy
    [SerializeField] private float m_leftBand;
    [SerializeField] private float m_rightBand;
    
    //time vars
    private float m_loopMovement; //time reference
    [SerializeField] private float m_elapsedTime = 0f;

    //range setting for a random move lentgh
    [SerializeField] private float m_minMoveRange;
    [SerializeField] private float m_maxMoveRange;
    
    private float m_leftDir = 5f;
    private float m_rightDir = 10f;
    private float m_angle = 0.1f;

    private void Start()
    {
        //picking a random range for left right movement
        m_loopMovement = Random.Range(m_minMoveRange, m_maxMoveRange);
    }

    void Update()
    {
        //calcul de temps
        m_elapsedTime = m_loopMovement += Time.deltaTime;
        
        //conditions de mouvement vers la droite
        if (m_loopMovement > 0 && m_loopMovement < 2)
        {
            transform.Translate(Vector3.right * m_speedEnemy * Time.deltaTime);
            transform.Rotate(Vector3.up * m_leftDir * Time.deltaTime);
            //print(m_loopMovement);
        }
        //conditions de mouvement vers la gauche
        else if (m_loopMovement >= 2 && m_loopMovement < 4)
        {
            transform.Translate(Vector3.left * m_speedEnemy * Time.deltaTime);
            transform.Rotate(Vector3.up * m_angle);
            transform.Rotate(Vector3.up * m_leftDir * Time.deltaTime);
            //print(m_loopMovement);
        }
        //reset movement set
        else if (m_loopMovement >= 4)
        {
            m_loopMovement = 0;
        }
        
        
        // delimite la taille des déplacements (gauche)
        if(transform.position.x > m_leftBand)
        {
            transform.position = new Vector3(m_leftBand, transform.position.y, transform.position.z);
            
        }
        // delimite la taille des déplacements (droite)
        if(transform.position.x < m_rightBand)
        {
            transform.position = new Vector3(m_rightBand, transform.position.y, transform.position.z);
        }
    }
    
    //destroy on collide to avoid overlaps in game
    private void OnTriggerEnter(Collider p_other)
    {
        Destroy(gameObject);
    }
}
