using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float elapsed = 0f;
    [SerializeField] private TextMeshProUGUI timerText;

    private static GameTimer instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateDisplay();
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (timerText == null)
            return;

        int totalSeconds = Mathf.FloorToInt(elapsed);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        timerText.text = $"TIME: {minutes}:{seconds:00}";
    }
}

