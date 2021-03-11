using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private GameObject m_player;

    private CharaController m_moveScript;

    private Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_moveScript = m_player.GetComponent<CharaController>();

        m_button = m_player.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LEFT"))
        {
            Debug.Log("OKK");
        }
    }
}
