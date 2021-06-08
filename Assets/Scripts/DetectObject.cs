using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectObject : MonoBehaviour
{
    bool mouseOver;
    Ray ray;
    RaycastHit hit;
    GameObject currentHit;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Start()
    {
        inventory = new Inventory();

    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Color startColor = Color.white;

        if (Physics.Raycast(ray, out hit))
        {
            currentHit = hit.collider.gameObject;
            if (currentHit.GetComponent<Collider>().tag.Equals("Phone") && Input.GetMouseButtonDown(0))
            {
                mouseOver = true;
                currentHit.GetComponent<Renderer>().material.color = Color.yellow;

                Destroy(currentHit);

                //float itemSlotCellSize = 30f;

                ItemWorld itemWorld = hit.collider.gameObject.GetComponent<ItemWorld>();
                if (itemWorld != null)
                {
                    inventory.AddItem(itemWorld.GetItem());
                    itemWorld.DestroySelf();
                }
            }
            else
            {
                mouseOver = false;
            }
        }

        if (!mouseOver)
        {
            
        }
    }
}