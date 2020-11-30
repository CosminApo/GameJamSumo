using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene in queue
        Time.timeScale = 1.0f;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
