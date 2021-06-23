using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlSwitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Credits");
    }
}