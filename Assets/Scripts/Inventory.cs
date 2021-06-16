using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;


    public void AddItem(Item item)
    {
        itemList.Add(item);

    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
