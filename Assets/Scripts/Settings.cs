using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject SettingScreen;
    public void OpenSettings()
    {
        MainScreen.gameObject.SetActive(false);
        SettingScreen.gameObject.SetActive(true);
    }
}
