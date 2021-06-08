using UnityEngine.UI;
using UnityEngine;

public class NextImage : MonoBehaviour
{
    // Public objects
    public Sprite[] sprites;

    //Private objects/variables
    private Image phone;
    private int spriteIndex;

    void Start()
    {
        phone = GetComponent<Image>(); // Get the image component of your button
        spriteIndex = 0; // Set the index to 0
        phone.sprite = sprites[spriteIndex]; // Set the image to the first image in your sprite array
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
}