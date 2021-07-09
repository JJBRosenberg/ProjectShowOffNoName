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
    public otherMovement playerSpeed;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject effect4;
    public GameObject effect5;
    public GameObject effect6;

    public void Start()
    {
        playerSpeed = FindObjectOfType<otherMovement>();
        spriteRenderer = gameObject.GetComponent<Image>();

    }

    private void Update()
    {
        if (anxiety < 1)
        {
            spriteRenderer.sprite = newSprite[0];
            effect1.gameObject.SetActive(false);
        }
        if (anxiety >= 1 && anxiety < 2)
        {
            spriteRenderer.sprite = newSprite[1];
            effect1.gameObject.SetActive(true);
            effect2.gameObject.SetActive(false);
        }
        if (anxiety >= 2 && anxiety < 3)
        {
            spriteRenderer.sprite = newSprite[2];
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(true);
            effect3.gameObject.SetActive(false);
        }
        if (anxiety >= 3 && anxiety < 4)
        {
            spriteRenderer.sprite = newSprite[3];
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(true);
            effect4.gameObject.SetActive(false);
        }
        if (anxiety >= 4 && anxiety < 5)
        {
            spriteRenderer.sprite = newSprite[4];
            effect3.gameObject.SetActive(false);
            effect4.gameObject.SetActive(true);
            effect5.gameObject.SetActive(false);
        }
        if (anxiety >= 5 && anxiety < 6)
        {
            spriteRenderer.sprite = newSprite[5];
            effect4.gameObject.SetActive(false);
            effect5.gameObject.SetActive(true);
            effect6.gameObject.SetActive(false);
        }
        if (anxiety >= 6 && anxiety < 7)
        {
            spriteRenderer.sprite = newSprite[6];
            playerSpeed.SmallSpeed();
            effect6.gameObject.SetActive(true);
            effect5.gameObject.SetActive(false);
        }
    }

    public void PhoneClicked()
    {
        isPhonedClicked = !isPhonedClicked;
        if (isPhonedClicked)
        {
            StopCoroutine(reverseTime());
            StartCoroutine(time());
            Debug.Log("PhoneClicked");
        }
        else if (!isPhonedClicked)
        {
            StopCoroutine(time());
            StartCoroutine(reverseTime());
            Debug.Log("PhoneUnclicked");
        }
    }
    private IEnumerator time()
    {
        while (isPhonedClicked)
        {
            yield return new WaitForSeconds(3);
            AnxietyUp();
        }
    }
    private IEnumerator reverseTime()
    {
        while (!isPhonedClicked)
        {
            yield return new WaitForSeconds(3);
            AnxietyDown();
        }
    }
    void AnxietyUp()
    {
        if (anxiety! < 6)
        {
            anxiety += 1;
            Debug.Log("Inreased Anxiety Level");
        }
    }

    void AnxietyDown()
    {
        if (anxiety > 0)
        {
            anxiety -= 1;
            Debug.Log("Decreased Anxiety Level");
        }
    }
}
