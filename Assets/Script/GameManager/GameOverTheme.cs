using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTheme : MonoBehaviour
{
    public AudioSource GameOver;


    private void Start()
    {
        GameOver.Play();
    }
}

