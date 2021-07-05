using UnityEngine.UI;
using UnityEngine;

public class NextImage : MonoBehaviour
{
    // Public objects
    public Sprite[] sprites;
    public Button[] ExtraButtons;
    [SerializeField] private int[] pictureTrigger;

    //Private objects/variables
    private Image phone;
    private GameObject screen;
    private int spriteIndex;

    void Start()
    {
        phone = GetComponent<Image>(); // Get the image component of your button
        screen = GetComponent<GameObject>();
        spriteIndex = 0; // Set the index to 0
        phone.sprite = sprites[spriteIndex]; // Set the image to the first image in your sprite array
    }
    private void Update()
    {
        hitThisNumber();
    }


    public void ifClicked()
    {
        spriteIndex++; // Increment the index
        if (spriteIndex > sprites.Length - 1) // Ensure that you stay within the array size
        {
            spriteIndex = 0;
        }
        phone.sprite = sprites[spriteIndex]; // Set the image
    }

    public void backClicked()
    {
        spriteIndex--; // Increment the index
        if (spriteIndex < 0) // Ensure that you stay within the array size
        {
            spriteIndex = sprites.Length - 1;
        }
        phone.sprite = sprites[spriteIndex]; // Set the image
    }

    private void hitThisNumber()
    {
        for(int i = 0; i < spriteIndex; i ++)
        {
            if (spriteIndex == pictureTrigger[i])
            {
                ExtraButtons[i].gameObject.SetActive(true);
            }
            else
            {
                ExtraButtons[i].gameObject.SetActive(false);
            }
        }
    }
}