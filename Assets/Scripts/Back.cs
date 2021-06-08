using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;

    public void GoBack()
    {
        MainMenu.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
    }
}
