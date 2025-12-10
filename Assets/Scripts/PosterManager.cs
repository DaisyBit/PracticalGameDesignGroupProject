using System.Collections.Generic;
using UnityEngine;

public class PosterManager : MonoBehaviour
{
    public static PosterManager Instance;

    public List<PosterData> collectedPosters = new List<PosterData>();

    void Awake()
    {
        Instance = this;
    }

    public void AddPoster(PosterData poster)
    {
        if (!collectedPosters.Contains(poster))
            collectedPosters.Add(poster);
    }
}
