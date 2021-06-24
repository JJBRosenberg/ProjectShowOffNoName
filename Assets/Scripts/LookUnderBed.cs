using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderBed : ItemContainer
{
    [SerializeField] private GameObject underBed;
    [SerializeField] private GameObject underBedNoHamster;
    [SerializeField] private GameObject underBedNoHamsterNoscrewDriver;
    [SerializeField] private bool isInRange;
    [SerializeField] ItemContainer itemContainer;
    [SerializeField] Item hamster;
    [SerializeField] Item screwDriver;
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
            StartCoroutine(itHappened());
        }
        if (Input.GetKeyDown(KeyCode.R) && isOpened)
        {
            underBed.SetActive(false);
            underBedNoHamster.SetActive(false);
            underBedNoHamsterNoscrewDriver.SetActive(false);
            isOpened = false;
            Debug.Log("closed");
        }
    }
    IEnumerator itHappened()
    {
        if(isOpened && Input.GetKeyDown(KeyCode.E) && itemContainer.ContainsItem(hamster))
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Hello");
            underBed.SetActive(false);
            underBedNoHamster.SetActive(true);
            yield return new WaitForSeconds(3);
            underBed.SetActive(false);
            underBedNoHamster.SetActive(false);
            underBedNoHamsterNoscrewDriver.SetActive(true);
            itemContainer.RemoveItem(hamster);
            itemContainer.AddItem(screwDriver);
        }
    }
}
