using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterCage : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item hamster;
    [SerializeField] ItemContainer itemContainer;
    [SerializeField] private Item carrot;

    private void Update()
    {
        takeCage();
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }


    public void takeCage()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (itemContainer.ContainsItem(carrot))
            {
                itemContainer.AddItem(hamster);
                itemContainer.RemoveItem(carrot);
                GameFeedback.Instance.SetText("Hamster taken!");
            }
            else
            {
                GameFeedback.Instance.SetText("Maybe hes hungry");
            }
        }

    }
}
