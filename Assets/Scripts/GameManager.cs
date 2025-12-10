using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private GameTimer gameTimer;

    private bool gameEnded = false;

    public static GameManager instance;

    public int score = 0;           // Player's score for the level
    public int badScore = 0;        // Player's bad score (if they do bad things, e.g. hitting enemies)

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make sure GameManager persists between scene changes
        }
    }

    void Start()
    {
        ResetGameValues();  // Reset score and bad score when the game starts
        if (gameOverMenu != null)
            gameOverMenu.HideMenu();
    }

    public void ResetGameValues()
    {
        score = 0;           // Reset the score
        badScore = 0;        // Reset the bad score
    }

    public void AddBadScore(int scoreToAdd)
    {
        badScore += scoreToAdd;
        Debug.Log($"Bad Score: {badScore}");
    }

    public void EndGame(int score)
    {
        if (gameEnded) return;
        gameEnded = true;

        float elapsedTime = gameTimer != null ? gameTimer.elapsed : 0f;

        // Calculate the final score
        float finalScore = (score * 10000f) - (elapsedTime * 6f);
        Debug.Log($"[GameManager] Game Over! Final Score = {finalScore}");
        Time.timeScale = 0f;

        if (gameOverMenu != null)
            gameOverMenu.ShowFinalScore(finalScore, elapsedTime);

        // Show bad score if it is greater than 0
        if (badScore > 0)
        {
            gameOverMenu.ShowFinalBadScore(badScore);
        }
    }
}
