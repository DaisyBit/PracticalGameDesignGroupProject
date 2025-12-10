using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStartMenu : MonoBehaviour
{
    public CanvasGroup menuGroup;
    public Button startButton;
    public TMP_Text menuText;  
    public string defaultText = "Welcome! Press Start to Begin"; 

    void Start()
    {
        ShowMenu(true);
        Time.timeScale = 0f;

        startButton.onClick.AddListener(CloseMenu);

        SceneManager.sceneLoaded += OnSceneLoaded;

        UpdateMenuText();
    }

    void CloseMenu()
    {
        ShowMenu(false);
        Time.timeScale = 1f;
    }

    void ShowMenu(bool visible)
    {
        menuGroup.alpha = visible ? 1 : 0;
        menuGroup.interactable = visible;
        menuGroup.blocksRaycasts = visible;
    }

    void UpdateMenuText()
    {
        if (menuText != null)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Level_IH") 
            {
                menuText.text = "Welcome to Level_IH! Press Start to Begin.";
            }
            else if (currentScene == "Level_JM") 
            {
                menuText.text = "Level_JM is Ready! Press Start to Begin!";
            }
            else
            {
                menuText.text = defaultText; 
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMenuText();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
