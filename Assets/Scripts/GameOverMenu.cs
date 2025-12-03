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
        {
            int totalSeconds = Mathf.FloorToInt(finalTime);
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            finalTimeText.text = $"Final Time: {minutes}:{seconds:00}";
        }

        Debug.Log("Game Over! Final Score: " + finalScore);
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
}
