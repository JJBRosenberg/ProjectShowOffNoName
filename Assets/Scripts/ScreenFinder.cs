using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFinder : MonoBehaviour
{
    public NextImage image;
    private void Start()
    {

    }
    public void SelectScene(int input)
    {
        image.spriteIndex = input;
    }
}
