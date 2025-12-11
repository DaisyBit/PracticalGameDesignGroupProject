using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button nextSceneButton;

    private void Start()
    {
        if (nextSceneButton != null)
        {
            nextSceneButton.onClick.AddListener(LoadNextScene);
            nextSceneButton.gameObject.SetActive(false);
        }
    }
    private void Awake()
{
    DontDestroyOnLoad(gameObject);
}


    public void ShowFinalScore(float finalScore, float elapsedTime)
{
    Time.timeScale = 1f; 
    gameObject.SetActive(true);

    if (finalScoreText != null)
        finalScoreText.text = $"Final Score: {Mathf.RoundToInt(finalScore)}\nTime: {Mathf.RoundToInt(elapsedTime)}";

    if (nextSceneButton != null)
        nextSceneButton.gameObject.SetActive(true);

    Canvas.ForceUpdateCanvases(); 
    Time.timeScale = 0f; 
}

public void ShowFinalBadScore(int badScore)
{
    Time.timeScale = 1f;
    gameObject.SetActive(true);

    if (finalScoreText != null)
        finalScoreText.text += $"\nBad Score: {badScore}";

    if (nextSceneButton != null)
        nextSceneButton.gameObject.SetActive(true);

    Canvas.ForceUpdateCanvases();
    Time.timeScale = 0f;
}


    public void HideMenu()
    {
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

public void LoadNextScene()
{
    HideMenu();

    Time.timeScale = 1f; 

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    else
    {
        Debug.Log("No next scene in the build settings.");
    }
}

}
