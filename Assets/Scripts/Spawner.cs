using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objectsToSpawn;

    void Start()
    {
        SpawnNoDuplicates();
    }

    void SpawnNoDuplicates()
    {
        var availablePoints = new System.Collections.Generic.List<Transform>(spawnPoints);

        foreach (GameObject obj in objectsToSpawn)
        {
            int index = Random.Range(0, availablePoints.Count);
            Transform point = availablePoints[index];

            Instantiate(obj, point.position, Quaternion.identity);

            availablePoints.RemoveAt(index);
        }
    }
}
