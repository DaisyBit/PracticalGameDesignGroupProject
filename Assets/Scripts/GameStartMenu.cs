using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    public CanvasGroup menuGroup;
    public Button startButton;

    void Start()
    {
        ShowMenu(true);
        Time.timeScale = 0f;

        startButton.onClick.AddListener(CloseMenu);
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
}
