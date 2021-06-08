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
    public int time;
    private GameObject phone;
    private bool gottenPhone;
    private bool gottenTablet;
    private bool gottenComputer;
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
