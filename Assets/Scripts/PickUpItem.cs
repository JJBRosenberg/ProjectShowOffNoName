using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] int amount = 1;
    private bool isInRange;
    private bool isEmpty;

    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isEmpty)
            {
                Item itemCopy = item.GetCopy();
                if (inventory.AddItem(itemCopy))
                {
                    if (amount == 0)
                    {


                        amount--;
                        isEmpty = true;

                    }
                }
                else itemCopy.Destroy();
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isInRange = false;
    }
}
