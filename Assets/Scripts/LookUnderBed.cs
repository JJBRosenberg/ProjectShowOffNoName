using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUnderBed : ItemContainer
{
    [SerializeField] private GameObject underBed;
    [SerializeField] private GameObject underBedNoHamster;
    [SerializeField] private GameObject underBedNoHamsterNoScrewdriver;
    [SerializeField] private bool isInRange;
    [SerializeField] private Item hamster;
    [SerializeField] private Item screwDriver;
    private bool isOpened = false;
    public ItemContainer itemContainer;
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
        if (isInRange && Input.GetKeyDown(KeyCode.E) && isOpened == false )
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

        if(Input.GetKeyDown(KeyCode.E) && isOpened && itemContainer.ContainsItem(hamster))
        {
            StartCoroutine(changeOverlay());
        }
    }
    IEnumerator changeOverlay()
    {
        underBed.SetActive(false);
        underBedNoHamster.SetActive(true);
        yield return new WaitForSeconds(3);
        underBedNoHamster.SetActive(false);
        underBedNoHamsterNoScrewdriver.SetActive(true);
        itemContainer.RemoveItem(hamster);
        itemContainer.AddItem(screwDriver);
    }
}
