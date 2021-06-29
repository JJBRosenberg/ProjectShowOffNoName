using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterCage : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item hamster;
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
        if ( isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemContainer.AddItem(hamster);
        }
    }
}
