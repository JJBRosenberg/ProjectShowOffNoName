using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer
{
	[SerializeField] protected ItemSlot	[] itemSlots;



	public  bool CanAddItem(Item item, int amount = 1)
	{
		int freeSpaces = 0;

		foreach (ItemSlot itemSlot in itemSlots)
		{
			if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
			{
				freeSpaces += item.MaximumStacks - itemSlot.Amount;
			}
		}
		return freeSpaces >= amount;
	}

	//adds the items to the inventory panel
	public  bool AddItem(Item item)
	{
		for (int i = 0; i < itemSlots.Length; i++)
		{
			if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID)){
				itemSlots[i].Item = item;
				itemSlots[i].Amount++;
				return true;
			}
		}

		return false;
	}

	//removes the items to the inventory panel
	public virtual bool RemoveItem(Item item)
	{
		for (int i = 0; i < itemSlots.Length; i++)
		{
			if (itemSlots[i].Item == item)
			{
				itemSlots[i].Amount--;
				itemSlots[i].Item = null;
				return true;
			}
		}
		return false;
	}

	//removes the items to the inventory panel using ID
	public virtual Item RemoveItem(string itemID)
	{
		for (int i = 0; i < itemSlots.Length; i++)
		{
			Item item = itemSlots[i].Item;
			if (item != null && item.ID == itemID)
			{
				itemSlots[i].Amount--;
				itemSlots[i].Item = null;
				return item;
			}
		}
		return null;
	}
	//Checks how many items are i the slot
	public  int ItemCount(Item item)
	{
		int number = 0;

		for (int i = 0; i < itemSlots.Length; i++)
		{
			if (itemSlots[i].Item == item)
			{
				number += itemSlots[i].Amount;
			}
		}
		return number;
	}
	//CLears all item slots
	public void Clear()
	{
		for (int i = 0; i < itemSlots.Length; i++)
		{
			if (itemSlots[i].Item != null && Application.isPlaying)
			{
				itemSlots[i].Item.Destroy();
			}
			itemSlots[i].Item = null;
			itemSlots[i].Amount = 0;
		}
	}
	//checks if the itemslots are full
    public  bool IsFull()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
			if(itemSlots[i].Item == null)
            {
				return false;
            }
        }
		return true;
    }
	//checks if an item slot contains an item
    public bool ContainsItem(Item item)
    {

		for (int i = 0; i < itemSlots.Length; i++)
		{ 
			if (itemSlots[i].Item == item )
			{
				return true;
			}
		}
		return false;
	}
	}

