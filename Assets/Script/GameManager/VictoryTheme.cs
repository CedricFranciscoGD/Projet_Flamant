using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTheme : MonoBehaviour
{
    public AudioSource VictorySound;
    // Start is called before the first frame update
    void Start()
    {
        VictorySound.Play();
    }
}
