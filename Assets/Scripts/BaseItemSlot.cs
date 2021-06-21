using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class BaseItemSlot : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image image;


    protected bool isPointerOver;
    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;

    public Color normalColor = Color.white;
    public Color disabledColor = Color.clear;

    private Item _item;

    //Gets the sprite Icon if there is one
    public Item Item
    {
        get { return _item; }
        set {
            _item = value;
                if(_item == null) {
                image.color = disabledColor;
            
            } else {
                image.sprite = _item.Icon;
                image.color = normalColor;
            }
                if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }
        }
    }
    //checks for the amount only needs 1
    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
        }
    }
    //fils in the image in the inspector
    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }
    Vector2 originalPosition;

    public virtual bool CanAddStack(Item item, int amount = 1)
    {
        return Item != null && Item.ID == item.ID;
    }
    public virtual bool CanReceiveItem(Item item)
    {
        return false;
    }
    //mouse events
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }

    protected virtual void OnDisable()
    {
        if (isPointerOver)
        {
            OnPointerExit(null);
        }
    }

}
