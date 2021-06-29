using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanelCode : MonoBehaviour
{
    public static bool isKeyPanelopen = false;
    [SerializeField] GameObject codePanel;
    [SerializeField] GameObject closedSafe;
    [SerializeField] GameObject openSafe;
    private void Update()
    {
        if (isKeyPanelopen)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openSafe.SetActive(true);
        }
    }
}
