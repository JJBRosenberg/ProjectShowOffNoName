using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        
    }

    public void NewGame()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
