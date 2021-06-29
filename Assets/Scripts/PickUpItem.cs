using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] public GameObject itemModel;
    public Inventory inventory;
    [SerializeField] int amount = 1;
    private bool isInRange;
    private bool isEmpty;

    //finds the invetory
    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();
    }


    //adds the item to the inventory removes model
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isEmpty)
            {
                Item itemCopy = item.GetCopy();
                if (inventory.AddItem(itemCopy))
                {
                    Debug.Log("YEs");
                    amount--;
                    isEmpty = true;
                    itemModel.SetActive(false);

                }
                else itemCopy.Destroy();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            Debug.Log("Can interact with: " + item.ID);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
            Debug.Log("Cannot interact with: " + item.ID);
        }
    }
}