using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpSound : MonoBehaviour
{

    public string sound;

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.F))
        {
            FMODUnity.RuntimeManager.PlayOneShot(sound);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
