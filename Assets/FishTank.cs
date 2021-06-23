using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTank : MonoBehaviour
{

    [SerializeField] private bool isInRange;
    [SerializeField] private Item item;
    [SerializeField] private Item itemBack;
    [SerializeField] private GameObject coinToDestory;
    public ItemContainer itemContainer;

    private void Update()
    {
        LookUnder(itemContainer);
    }

    public void LookUnder(IItemContainer itemContainer)
    {
        if (itemContainer.ContainsItem(item) && isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemContainer.AddItem(itemBack);
            itemContainer.RemoveItem(item);
            Destroy(coinToDestory);
        }
    }
}
