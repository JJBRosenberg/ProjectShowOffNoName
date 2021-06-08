using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public bool taken;
    public bool inside;
    public GameObject CraftingTable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inside = false;

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && inside == true && taken == false)
        {
            CraftingTable.gameObject.SetActive(false);
            taken = true;
        }  
        
        if  (Input.GetKeyDown(KeyCode.F) && inside == true && taken == true)
            {
                CraftingTable.gameObject.SetActive(true);
                taken = false;
            }
        
    }
}
