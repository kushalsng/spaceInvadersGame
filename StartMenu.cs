using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
