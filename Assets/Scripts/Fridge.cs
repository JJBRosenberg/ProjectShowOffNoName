using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private Item cylinder;
    [SerializeField] ItemContainer itemContainer;
    [SerializeField] private Item fridgeItem;
    [SerializeField] int timeToWait;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && itemContainer.ContainsItem(cylinder))
        {
            StartCoroutine(fridgeStuff());
            Debug.Log("fridge");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }

    private IEnumerator fridgeStuff()
    {

        yield return new WaitForSeconds(timeToWait);


        itemContainer.RemoveItem(cylinder);
        itemContainer.AddItem(fridgeItem);

    }
}
