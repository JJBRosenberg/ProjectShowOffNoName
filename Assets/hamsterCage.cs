using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterCage : MonoBehaviour
{
    [SerializeField] private bool isInRange;
    [SerializeField] private Item carrot;
    [SerializeField] private Item hamster;
    [SerializeField] private GameObject itemToDestory;
    public ItemContainer itemContainer;

    private void Update()
    {
        takeCage(itemContainer);
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
