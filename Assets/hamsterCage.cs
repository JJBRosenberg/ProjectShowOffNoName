using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterCage : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item carrot;
    [SerializeField] private Item hamster;
    [SerializeField] private GameObject itemToDestory;
    public ItemContainer itemContainer;

    private void Update()
    {
        takeCage(itemContainer);
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }


    public void takeCage(IItemContainer itemContainer)
    {
        if (itemContainer.ContainsItem(carrot) && isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemContainer.AddItem(hamster);
            itemContainer.RemoveItem(carrot);
            Destroy(itemToDestory);
        }
    }
}
