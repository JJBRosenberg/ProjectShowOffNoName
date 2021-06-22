using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyMeter : MonoBehaviour
{
    public int anxiety = 0;
    private bool isPhonedClicked;
    private Image spriteRenderer;
    public Sprite[] newSprite;

    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (anxiety < 1)
        {
            spriteRenderer.sprite = newSprite[0];
        }
        if (anxiety >= 1 && anxiety < 2)
        {
            spriteRenderer.sprite = newSprite[1];
        }
        if (anxiety >= 2 && anxiety < 3)
        {
            spriteRenderer.sprite = newSprite[2];
        }
        if (anxiety >= 3 && anxiety < 4)
        {
            spriteRenderer.sprite = newSprite[3];
        }
        if (anxiety >= 4 && anxiety < 5)
        {
            spriteRenderer.sprite = newSprite[4];
        }
        if (anxiety >= 5 && anxiety < 6)
        {
            spriteRenderer.sprite = newSprite[5];
        }
    }

    public void PhoneClicked()
    {
        isPhonedClicked = !isPhonedClicked;
        if (isPhonedClicked)
        {
            Debug.Log("start");
            StopCoroutine(reverseTime());
            StartCoroutine(time());
        } else if(!isPhonedClicked)
        {
            Debug.Log("stop ");
            StopCoroutine(time());
            StartCoroutine(reverseTime());
        }
    }
    IEnumerator time()
    {
        while (isPhonedClicked)
        {
            yield return new WaitForSeconds(3);
            AnxietyUp();
        }
    }
    IEnumerator reverseTime()
    {
        while (!isPhonedClicked)
        {
            yield return new WaitForSeconds(3);
            AnxietyDown();
        }
    }
    void AnxietyUp()
    {
        anxiety += 1;
    }

    void AnxietyDown()
    {
        anxiety -= 1;
    }
}
