using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public Canvas KidsPhone;
    private bool inPhone;
    private Inventory inventory;
    private DetectPlayer detection;
    private GameObject phone;
    
    [SerializeField] private UI_Inventory uiInventory;
    private void Start()
    {
    }
    private void Update()
    {
        CheckForIphone();
    }


    private void CheckForIphone()
    {
        if (inPhone == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(phone);
        }
    }

}
