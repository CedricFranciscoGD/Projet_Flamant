using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputValue = Input.GetAxis("Vertical");

        // deplace le personnage
        transform.Translate(Vector3.right * m_speed * Time.deltaTime * inputValue);
<<<<<<< Updated upstream
=======
        transform.Translate(Vector3.back * m_speed * Time.deltaTime * inputValue2);
>>>>>>> Stashed changes

    }
}
