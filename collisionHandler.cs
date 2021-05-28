using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionGO;
    [SerializeField] float levelDelay = 2f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        Invoke("SceneReload", levelDelay);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosionGO.SetActive(true);
        
    }

    private void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
