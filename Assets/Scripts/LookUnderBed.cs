using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderBed : ItemContainer
{
    [SerializeField] private GameObject underBed;
    [SerializeField] private bool isInRange;
    private bool isOpened = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && isOpened == false)
        {
            underBed.SetActive(true);
            isOpened = true;
            Debug.Log("opened");
        }
        if (isInRange && Input.GetKeyDown(KeyCode.R) && isOpened)
        {
            underBed.SetActive(false);
            isOpened = false;
            Debug.Log("closed");
        }
    }

}
