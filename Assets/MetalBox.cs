using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBox : MonoBehaviour
{
    [SerializeField] private Item wire;
    [SerializeField] ItemContainer itemContainer;
    [SerializeField] private GameObject firstBox;
    [SerializeField] private GameObject secondBox;
    [SerializeField] private bool isInRange;

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
    private void Update()
    {
        useBox();
    }

    private void useBox()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (itemContainer.ContainsItem(wire))
            {
                itemContainer.RemoveItem(wire);
                secondBox.gameObject.SetActive(true);
                firstBox.gameObject.SetActive(false);
                GameFeedback.Instance.SetText("Opened!");
            }
            else
            {
                GameFeedback.Instance.SetText("Cannot open this");
            }

        }
    }

}
