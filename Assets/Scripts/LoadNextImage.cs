using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.Collections;

public class LoadNextImage : MonoBehaviour
{

    public Image[] gallery;
    public Image displayImage;
    public Button nextImg;
    public Button prevImg;
    public int i = 0;



    public void BtnNext()
    {
        if (i + 1 < gallery.Length)
        {
            i++;
        }
    }

    public void BtnPrev()
    {
        if (i - 1 > 0)
        {
            i--;
        }
    }
    void Update()
    {
        Debug.Log(i);
        displayImage = gallery[i];
    }
}