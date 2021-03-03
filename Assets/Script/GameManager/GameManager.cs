using System;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Le jeu n'est pas arrêté
    private bool m_gameIsOver = true;

    /// <summary>
    /// Rentre dans cette fonction si le joueur entre en collision avec un élément enemy
    /// Puis reance le jeu
    /// </summary>
    public void EndGame()
    {
        if (m_gameIsOver == false)
        {
            m_gameIsOver = true;
            Debug.Log("GAME OVER");
            Restart();
        }
    }

    
    
    
    /// <summary>
    /// Relance le jeu à la scène 1
    /// </summary>
    void Restart()
    {
        SceneManager.LoadScene("Level_1");
    }
}