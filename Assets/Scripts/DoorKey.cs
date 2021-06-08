using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public AudioSource key;
    public bool inTrigger;

    //if the player is enters
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    //if the player is exits
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    private void Update()
    {
        if(inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Pick up the key
                DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 460, 200, 25), "Press E to take key");
        }
    }
}
