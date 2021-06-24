using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public GameObject phoneScreen;
    public GameObject tablet;
    public GameObject computer;
    public GameObject firstModel;
    public GameObject secondModel;
    public GameObject thirdModel;
    public int time;
    private GameObject phone;
    private bool gottenPhone;
    private bool gottenTablet;
    private bool gottenComputer;
    private int maxAnxiety = 20;
    private bool isPhonedUsed;
    private void Start()
    {
        AnimateBar();

        phone = GameObject.FindWithTag("Phone");
    }

    private void Update()
    {
        CheckForItems();
        OpenItems();
        CloseItems();
        Lost();
        //CheckTime();
    }
    public void phoneClicked()
    {
        if (isPhonedUsed = false)
        {
            isPhonedUsed = true;
        } else
        {
            isPhonedUsed = false;
        }
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }

    public void Lost()
    {
        if (Time.time >= time)
        {
            SceneManager.LoadScene("Loss Scene");
        }
    }

    void CheckForItems()
    {
        if (!GameObject.FindWithTag("Phone"))
        {
            gottenPhone = true;
        }

        if (!GameObject.FindWithTag("Tablet"))
        {
            gottenTablet = true;
        }

        if (!GameObject.FindWithTag("Computer"))
        {
            gottenComputer = true;
        }

    }

    void OpenItems()
    {
        if (gottenPhone == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            phoneScreen.gameObject.SetActive(true);
        }

        if (gottenTablet == true && Input.GetKeyDown(KeyCode.Alpha2))
        {
            tablet.gameObject.SetActive(true);
        }

        if (gottenComputer == true && Input.GetKeyDown(KeyCode.Alpha3))
        {
            computer.gameObject.SetActive(true);
        }
    }
    IEnumerator TimerCoroutine()
    {

        float anxiety = 0;

        while (anxiety <= maxAnxiety)
        {
            anxiety += Time.deltaTime;
            yield return null;
        }
    }

    public void CheckTime()
    {
        if (time <100)
        {
            firstModel.gameObject.SetActive(true);
            secondModel.gameObject.SetActive(false);
            thirdModel.gameObject.SetActive(false);
        }

        if (time >= 100 && time < 200)
        {
            firstModel.gameObject.SetActive(false);
            secondModel.gameObject.SetActive(true);
            thirdModel.gameObject.SetActive(false);
        }
        if (time >= 200)
        {
            firstModel.gameObject.SetActive(true);
            secondModel.gameObject.SetActive(false);
            thirdModel.gameObject.SetActive(true);
        }


    }
    void CloseItems()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            phoneScreen.gameObject.SetActive(false);
            tablet.gameObject.SetActive(false);
            tablet.gameObject.SetActive(false);

        }
    }
    
}
