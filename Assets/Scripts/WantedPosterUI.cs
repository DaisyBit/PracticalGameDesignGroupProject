using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WantedPosterUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject wantedMenu;
    public Image posterImage;
    public Button nextButton;
    public Button prevButton;
    public TMP_Text noPosterText;

    private int currentIndex = 0;

    void Start()
    {
        wantedMenu.SetActive(false);
        posterImage.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        noPosterText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isActive = !wantedMenu.activeSelf;
            wantedMenu.SetActive(isActive);
            posterImage.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(false);
            noPosterText.gameObject.SetActive(false);

            if (isActive)
            {
                UpdateUI();
            }
        }
    }

    public void UpdateUI()
    {
        List<PosterData> posters = PosterManager.Instance.collectedPosters;

        if (posters.Count == 0)
        {
            // No posters collected
            posterImage.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(false);

            noPosterText.gameObject.SetActive(true);
            noPosterText.text = "No posters collected!";
            return;
        }

        // There is at least one poster
        noPosterText.gameObject.SetActive(false);
        posterImage.gameObject.SetActive(true);

        // Clamp current index
        currentIndex = Mathf.Clamp(currentIndex, 0, posters.Count - 1);

        // Display current poster
        posterImage.sprite = posters[currentIndex].posterSprite;

        // Show buttons only if more than 1 poster
        nextButton.gameObject.SetActive(posters.Count > 1);
        prevButton.gameObject.SetActive(posters.Count > 1);
    }

    public void NextPoster()
    {
        currentIndex++;
        if (currentIndex >= PosterManager.Instance.collectedPosters.Count)
            currentIndex = 0; // wrap around
        UpdateUI();
    }

    public void PreviousPoster()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = PosterManager.Instance.collectedPosters.Count - 1; // wrap around
        UpdateUI();
    }
}
