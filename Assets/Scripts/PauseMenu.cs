using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(0); //load next scene in queue
    }

    public void unFreezeTime()
    {
        Time.timeScale = 1.0f;
    }
    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
