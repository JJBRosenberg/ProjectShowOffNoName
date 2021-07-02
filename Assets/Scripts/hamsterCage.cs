using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamsterCage : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item hamster;
    [SerializeField] ItemContainer itemContainer;

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
        if ( isInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemContainer.AddItem(hamster);
            GameFeedback.Instance.SetText("Hamster taken!");
        }
    }
}
