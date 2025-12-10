using UnityEngine;

public class EnemyScoreManager : MonoBehaviour
{
    public static EnemyScoreManager instance;

    public int badScore = 0;
    public int maxScore = 1;

    private GameManager gameManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void AddEnemyPoint()
    {
        badScore++;
        Debug.Log("Bad Score: " + badScore);

        // If badScore reaches the threshold, we still show the bad score in the game over menu
        if (badScore >= maxScore && gameManager != null)
        {
            gameManager.EndGame(gameManager.score); // Trigger the game over logic and pass the current score
        }
    }
}
