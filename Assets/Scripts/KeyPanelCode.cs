using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanelCode : MonoBehaviour
{
    public static bool isKeyPanelopen = false;
    public static bool isColorPanelopen = false;
    public ItemContainer inventory;
    [SerializeField] Item safeKey;
    [SerializeField] GameObject codePanel;
    [SerializeField] GameObject closedSafe;
    [SerializeField] GameObject openSafe;

    private void Start()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openSafe.SetActive(false);
    }

    private void FixedUpdate()
    {
    }
    private void Update()
    {
        if (isKeyPanelopen && isColorPanelopen && inventory.ContainsItem(safeKey))
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openSafe.SetActive(true);
            Debug.Log("opened");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            codePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            codePanel.SetActive(false);
        }
    }
}

