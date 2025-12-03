using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;   

    [Header("Spawn Points")]
    public Transform[] spawnPoints;      

    void Start()
    {
        SpawnAllObjects();
    }

    void SpawnAllObjects()
    {
        if (objectsToSpawn.Length != 6)
        {
            Debug.LogError("You must assign exactly 6 objects to spawn.");
            return;
        }

        if (spawnPoints.Length < 6)
        {
            Debug.LogError("You must assign at least 6 spawn points.");
            return;
        }

        Shuffle(spawnPoints);

        for (int i = 0; i < 6; i++)
        {
            Instantiate(objectsToSpawn[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    void Shuffle(Transform[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            var temp = arr[i];
            arr[i] = arr[rand];
            arr[rand] = temp;
        }
    }
}
