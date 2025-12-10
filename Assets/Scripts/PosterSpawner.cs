using UnityEngine;

public class PosterSpawner : MonoBehaviour
{
    public GameObject posterPrefab;  
    public Transform spawnLocation; 
    public bool isVisible = false;  

    private void Start()
    {
        HidePosters();
    }

    private void Update()
    {
        if (isVisible && posterPrefab != null && spawnLocation != null)
        {
            SpawnPoster();
        }
    }

    private void SpawnPoster()
    {
        GameObject poster = Instantiate(posterPrefab, spawnLocation.position, Quaternion.identity);
        poster.SetActive(true);  
    }

    public void ShowPosters()
    {
        isVisible = true; 
    }

    public void HidePosters()
    {
        isVisible = false; 
    }
}
