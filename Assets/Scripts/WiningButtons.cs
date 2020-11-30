using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WiningButtons : MonoBehaviour
{

    public void QuitToMenu()
    {
        Time.timeScale = 1.0f; SceneManager.LoadScene(0); //load next scene in queue     }
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f; 
    }
}
