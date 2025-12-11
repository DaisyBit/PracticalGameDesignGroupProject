using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SwitchButton : MonoBehaviour
{
    public static SwitchButton instance;

    public GameObject spawner;
    public Color activeColor = Color.red;
    public Color defaultColor = Color.white;
    public bool isActive = false;

    private Light2D globalLight;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetLightingColor(defaultColor);
        DeactivateSpawner();

        globalLight = FindObjectOfType<Light2D>();

        if (globalLight == null)
            Debug.LogError("No Light2D found in the scene.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            ToggleButtonState();
    }

    private void ToggleButtonState()
    {
        isActive = !isActive;

        if (isActive)
        {
            ActivateSpawner();
            SetLightingColor(activeColor);
        }
        else
        {
            DeactivateSpawner();
            SetLightingColor(defaultColor);
        }
    }

    private void SetLightingColor(Color color)
    {
        if (globalLight != null)
            globalLight.color = color;
    }

    private void ActivateSpawner()
    {
        if (spawner != null)
            spawner.SetActive(true);
    }

    private void DeactivateSpawner()
    {
        if (spawner != null)
            spawner.SetActive(false);
    }
}
