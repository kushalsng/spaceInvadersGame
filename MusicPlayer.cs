using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] GameObject audio;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            audio.SetActive(true);
        }
        else
        {
            audio.SetActive(false);
        }
    }
    // Start is called before the first frame update

}
