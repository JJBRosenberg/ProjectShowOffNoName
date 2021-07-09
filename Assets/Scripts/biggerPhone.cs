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
            image.rectTransform.sizeDelta = new Vector2(260, 260);
            transform.Translate(825, 280, 0);
            isClicked = true;
            GameFeedback.Instance.SetText("Opened");
        } else if (isClicked)
        {
            image.rectTransform.sizeDelta = new Vector2(100, 100) ;
            transform.Translate(-825, -280, 0);
            isClicked = false;
            GameFeedback.Instance.SetText("Closed");
        } 
    }

}
