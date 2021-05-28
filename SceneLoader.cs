using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MainGame", delayTime);
    }

    // Update is called once per frame

    void MainGame()
    {
        SceneManager.LoadScene(1);
    }
}
