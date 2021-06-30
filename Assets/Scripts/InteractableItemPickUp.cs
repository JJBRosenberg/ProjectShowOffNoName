using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemPickUp : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item key;
    [SerializeField] private GameObject itemToDestory;
    [SerializeField] ItemContainer itemContainer;

    private void Update()
    {
        takeCage();
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }


    public void takeCage()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemContainer.AddItem(key);
            Destroy(itemToDestory);
        }
    }
}
