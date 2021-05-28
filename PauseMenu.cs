using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Pause"))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
