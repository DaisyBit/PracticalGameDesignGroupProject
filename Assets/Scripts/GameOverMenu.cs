using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalTimeText;

    public void ShowFinalScore(float finalScore, float finalTime)
    {
        gameObject.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = $"Final Score: {Mathf.RoundToInt(finalScore)}";

        if (finalTimeText != null)
            finalTimeText.text = FormatTime(finalTime);

        Debug.Log("Game Over! Final Score: " + finalScore);
    }
        public void ShowFinalBadScore(float finalBadScore, float finalTime)
    {
        gameObject.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = $"Final Score: {Mathf.RoundToInt(finalBadScore)}";

        if (finalTimeText != null)
            finalTimeText.text = FormatTime(finalTime);

        Debug.Log("Game Over! Final Score: " + finalBadScore);
    }

    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

      public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private static string FormatTime(float elapsedSeconds)
    {
        int totalSeconds = Mathf.FloorToInt(elapsedSeconds);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return $"Final Time: {minutes}:{seconds:00}";
    }
}
