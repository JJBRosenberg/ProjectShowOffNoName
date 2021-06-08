using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //if the player enters the trigger
        if (other.gameObject.tag == "Player")
        {
            //Load the next scene
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }
    }
}
