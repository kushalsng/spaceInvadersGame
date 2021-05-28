using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 2;
    [SerializeField] int scorePerDeath = 20;
    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider colliderr = gameObject.AddComponent<BoxCollider>();
        colliderr.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
            scoreBoard.ScoreHit(scorePerDeath);
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        GameObject FX = Instantiate(DeathFx, transform.position, Quaternion.identity);
        FX.transform.parent = parent;
        Destroy(gameObject);
    }
}
