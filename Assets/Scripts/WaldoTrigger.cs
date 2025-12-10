using UnityEngine;

public class WaldoTrigger : MonoBehaviour
{
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SwitchButton.instance != null && SwitchButton.instance.isActive && other.CompareTag(playerTag))
        {
            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
    }
}
