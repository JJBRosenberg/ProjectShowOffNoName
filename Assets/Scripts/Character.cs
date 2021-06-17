using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Image draggableItem;
    [SerializeField] CraftingWindow craftingWindow;

    private BaseItemSlot draggedSlot;
    private void Start()
    {
        inventory.OnBeginDragEvent += OnBeginDrag;
        inventory.OnEndDragEvent += OnEndDrag;
        inventory.OnDragEvent += OnDrag;
        inventory.OnDropEvent += OnDrop;
    }

    private void OnBeginDrag(BaseItemSlot itemSlot)
    {
        if(itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void OnEndDrag(BaseItemSlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void OnDrag(BaseItemSlot itemSlot)
    {
        if(draggableItem.enabled)
            draggableItem.transform.position = Input.mousePosition;
    }
    private void OnDrop(BaseItemSlot itemSlot)
    {
        if (draggableItem == null) return;
        Item draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;
        draggedSlot.Item = draggedItem;
        draggedSlot.Amount = itemSlot.Amount;
        itemSlot.Item = draggedItem;
        itemSlot.Amount = draggedItemAmount;
    }


}
