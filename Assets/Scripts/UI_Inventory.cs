using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public GameObject Phone;
    [SerializeField]
    private GameObject itemPrefab;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Item item in inventory.GetItemList())
        {
            int x = 0;
            int y = 0;
            //float itemSlotCellSize = 30f;
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            //itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            Image image = itemSlotRectTransform.GetComponent<Image>();
            image.sprite = item.GetSprite();
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }

}
