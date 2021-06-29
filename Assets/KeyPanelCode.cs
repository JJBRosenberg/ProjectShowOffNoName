using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanelCode : MonoBehaviour
{
    public static bool isKeyPanelopen = false;
    public static bool isColorPanelopen = false;
    [SerializeField] GameObject codePanel;
    [SerializeField] GameObject closedSafe;
    [SerializeField] GameObject openSafe;

    private void Start()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openSafe.SetActive(false);
    }
    private void Update()
    {
        if (isKeyPanelopen && isColorPanelopen)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openSafe.SetActive(true);
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

