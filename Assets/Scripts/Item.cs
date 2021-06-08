using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Phone,
        Tablet,
        Computer,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Phone: return ItemAssets.Instance.phoneSprite;
            case ItemType.Tablet: return ItemAssets.Instance.tabletSprite;
            case ItemType.Computer: return ItemAssets.Instance.computerSprite;
        }
    }
}
