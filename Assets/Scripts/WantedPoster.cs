using UnityEngine;

public class WantedPoster : MonoBehaviour
{
    public string posterName;
    public Sprite posterSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked up: " + posterName);

            PosterManager.Instance.AddPoster(new PosterData
            {
                posterName = posterName,
                posterSprite = posterSprite
            });

            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public class PosterData
{
    public string posterName;
    public Sprite posterSprite;
}
