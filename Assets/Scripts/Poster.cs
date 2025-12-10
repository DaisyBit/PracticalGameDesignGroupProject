using UnityEngine;

public class Poster : MonoBehaviour
{
    public SwitchButton switchButton; 

    private void OnEnable()
    {
        if (switchButton != null)
        {
            if (switchButton.isActive)
            {
                this.gameObject.AddComponent<EnemyTrigger>();
            }
            else
            {
                this.gameObject.AddComponent<WaldoTrigger>();
            }
        }
        else
        {
            Debug.LogError("SwitchButton reference is missing. Please assign it via the Inspector.");
        }
    }
}
