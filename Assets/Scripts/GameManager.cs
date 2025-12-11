using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private GameTimer gameTimer;

    public int score = 0;
    public int badScore = 0;

    private int[] scoreThresholds = {6, 12, 18};
    private int[] badScoreThresholds = {1, 2, 3};
    private bool[] scoreTriggered;
    private bool[] badScoreTriggered;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        scoreTriggered = new bool[scoreThresholds.Length];
        badScoreTriggered = new bool[badScoreThresholds.Length];
    }

    private void Start()
    {
        ResetGameValues();
        if (gameOverMenu != null)
            gameOverMenu.HideMenu();
    }

    public void ResetGameValues()
    {
        score = 0;
        badScore = 0;
        for (int i = 0; i < scoreTriggered.Length; i++)
            scoreTriggered[i] = false;
        for (int i = 0; i < badScoreTriggered.Length; i++)
            badScoreTriggered[i] = false;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
        CheckGameOver();
    }

    public void AddBadScore(int amount)
    {
        badScore += amount;
        Debug.Log($"Bad Score: {badScore}");
        CheckGameOver();
    }

    public void CheckGameOver()
    {
        for (int i = 0; i < scoreThresholds.Length; i++)
        {
            if (!scoreTriggered[i] && score >= scoreThresholds[i])
            {
                scoreTriggered[i] = true;
                EndGame();
            }
        }

        for (int i = 0; i < badScoreThresholds.Length; i++)
        {
            if (!badScoreTriggered[i] && badScore >= badScoreThresholds[i])
            {
                badScoreTriggered[i] = true;
                EndGame();
            }
        }
    }

public void EndGame()
{
    float elapsedTime = gameTimer != null ? gameTimer.elapsed : 0f;
    float finalScore = (score * 10000f) - (elapsedTime * 6f);
    Debug.Log($"Game Over! Final Score = {finalScore}");

    Time.timeScale = 1f; 
    if (gameOverMenu != null)
    {
        gameOverMenu.ShowFinalScore(finalScore, elapsedTime);
        if (badScore > 0)
            gameOverMenu.ShowFinalBadScore(badScore);
    }

    Time.timeScale = 0f;
}

}
