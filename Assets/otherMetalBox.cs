using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherMetalBox : MonoBehaviour
{
    [SerializeField] private GameObject firstSafe;
    [SerializeField] private GameObject secondSafe;
    [SerializeField] private GameObject numberPad;
    [SerializeField] private bool isInRange;
    [SerializeField] private ItemContainer itemContainer;
    [SerializeField] private Item wire;
    [SerializeField] private BoxCollider metalCollider;
    private bool isOpen;

    private void Start()
    {
        firstSafe.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isInRange = false;
    }

    private void Update()
    {
        usingBox();
        if(isOpen)
        {
            firstSafe.gameObject.SetActive(false);
            secondSafe.gameObject.SetActive(true);
            metalCollider.gameObject.SetActive(true);
        }
    }

    private void usingBox()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            numberPad.SetActive(true);
        }
        else
        {
            numberPad.SetActive(false);
        }
    }

    private void ifCorrect()
    {
        isOpen = true;
    }
}

