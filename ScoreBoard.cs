using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    
    int EnemyDestroyed;
    Text scoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = EnemyDestroyed.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        EnemyDestroyed = EnemyDestroyed + scorePerHit;
        scoreText.text = EnemyDestroyed.ToString();
    }

}
