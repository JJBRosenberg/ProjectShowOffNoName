using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public GameObject firstCamera;
    public GameObject secondCamera;
    public GameObject thirdCamera;
    public GameObject firstModel;
    public GameObject secondModel;
    public GameObject thirdModel;
    private bool firstTurned;
    private bool secondTurned;
    private bool thirdTurned;
    public float time;
    private GameObject phone;
    private bool gottenPhone;
    private bool gottenTablet;
    private bool gottenComputer;
    private int maxAnxiety = 20;
    private bool isPhonedUsed;
    void Start()
    {
        AnimateBar();

    }
    
    private void Update()
    {
        CheckForItems();
        Lost();
        CheckTime();
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
        if (Time.time >= 300)
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
        
        if (Time.time <100 && !firstTurned)
        {
            firstModel.gameObject.SetActive(true);
            secondModel.gameObject.SetActive(false);
            thirdModel.gameObject.SetActive(false);
            firstCamera.SetActive(true);
            secondCamera.SetActive(false);
            thirdCamera.SetActive(false);
            firstTurned = true;
            secondTurned = false;
            thirdTurned = false;
        }
        
        if (Time.time >= 100 && Time.time < 200 && !secondTurned)
        {
            firstModel.gameObject.SetActive(false);
            thirdModel.gameObject.SetActive(false);
            secondModel.transform.localPosition = firstModel.transform.localPosition;
            secondModel.transform.position = firstModel.transform.position;
            secondModel.transform.rotation = firstModel.transform.rotation;
            secondModel.transform.rotation = firstModel.transform.rotation;
            secondModel.gameObject.SetActive(true);
            firstCamera.SetActive(false);
            secondCamera.SetActive(true);
            thirdCamera.SetActive(false);
            firstTurned = false;
            secondTurned = true;
            thirdTurned = false;

        }
        if (Time.time >= 200 && !thirdTurned)
        {
            firstModel.gameObject.SetActive(false);
            secondModel.gameObject.SetActive(false);
            thirdModel.transform.localPosition = secondModel.transform.localPosition;
            thirdModel.transform.position = secondModel.transform.position;
            thirdModel.transform.rotation = secondModel.transform.rotation;
            thirdModel.transform.rotation = secondModel.transform.rotation;
            thirdModel.gameObject.SetActive(true);
            firstCamera.SetActive(false);
            secondCamera.SetActive(false);
            thirdCamera.SetActive(true);
            firstTurned = false;
            secondTurned = false;
            thirdTurned = true;
        }


    }
    
}
