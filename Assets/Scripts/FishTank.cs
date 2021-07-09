using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishTank : MonoBehaviour
{

    [SerializeField] private bool isInRange;
    [SerializeField] private Item item;
    [SerializeField] private Item itemBack;
    public bool inTrigger;
    [SerializeField] private GameObject coinToDestory;
    public ItemContainer itemContainer;
    [SerializeField] bool close;

    private void Start()
    {
        close = true;
    }

    //Checks if player entered 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
    //Checks if player exited
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
    private void Update()
    {
        LookUnder();
    }


    public void LookUnder()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (itemContainer.ContainsItem(item))
            {

                itemContainer.AddItem(itemBack);
                itemContainer.RemoveItem(item);
                Destroy(coinToDestory);
                GameFeedback.Instance.SetText("Coin half taken!");

            }
            else
            {
                GameFeedback.Instance.SetText("There is something inside. Press E to interact with the correct item.");
            }
        }
    }
}
