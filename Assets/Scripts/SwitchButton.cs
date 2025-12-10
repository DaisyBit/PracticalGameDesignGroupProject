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
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetLightingColor(defaultColor);
        DeactivateSpawner();

        globalLight = FindObjectOfType<Light2D>(); 

        if (globalLight == null)
        {
            Debug.LogError("No Light2D found in the scene. Please make sure there is a Light2D in your scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the button. Toggling state.");
            ToggleButtonState();
        }
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
        {
            globalLight.color = color;  
        }
    }

    private void ActivateSpawner()
    {
        if (spawner != null)
        {
            spawner.SetActive(true);
            ChangeTrigger(true);
        }
    }

    private void DeactivateSpawner()
    {
        if (spawner != null)
        {
            spawner.SetActive(false);
            ChangeTrigger(false);
        }
    }

    private void ChangeTrigger(bool isEnemyTrigger)
    {
        var triggerables = FindObjectsOfType<MonoBehaviour>();

        foreach (var triggerable in triggerables)
        {
            if (triggerable is WaldoTrigger waldoTrigger)
            {
                waldoTrigger.gameObject.GetComponent<Collider2D>().enabled = !isEnemyTrigger;
            }
            else if (triggerable is EnemyTrigger enemyTrigger)
            {
                enemyTrigger.gameObject.GetComponent<Collider2D>().enabled = isEnemyTrigger;
            }
        }
    }
}
