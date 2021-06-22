using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class biggerPhone : MonoBehaviour
{
    private Image image;
    private RectTransform start;
    private RectTransform end;
    private bool isClicked;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ifClicked()
    {

        if (!isClicked)
        {
            image.rectTransform.sizeDelta = new Vector2(150, 150);
            isClicked = true;
            Debug.Log("Opened");
        } else if (isClicked)
        {
            image.rectTransform.sizeDelta = new Vector2(100, 100) ;
            isClicked = false;
            Debug.Log("Closed");
        } 
    }

}
