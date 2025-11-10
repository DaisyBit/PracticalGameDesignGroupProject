using UnityEngine;
using UnityEngine.UI;

public class WantedPosterMenu : MonoBehaviour
{
    public CanvasGroup menuGroup;   
    public Image displayImage;      
    public Sprite[] images;        

    private bool isOpen = false;
    private int currentIndex = 0;

    void Start()
    {
        SetMenuVisible(false);
    }

    void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            SetMenuVisible(isOpen);
        }

 
        if (isOpen && Input.GetMouseButtonDown(0))
        {
            CycleImage();
        }
    }

    void SetMenuVisible(bool visible)
    {
        menuGroup.alpha = visible ? 1 : 0;
        menuGroup.interactable = visible;
        menuGroup.blocksRaycasts = visible;
    }

    void CycleImage()
    {
        if (images == null || images.Length == 0)
            return;

        currentIndex = (currentIndex + 1) % images.Length;
        displayImage.sprite = images[currentIndex];
    }
}
