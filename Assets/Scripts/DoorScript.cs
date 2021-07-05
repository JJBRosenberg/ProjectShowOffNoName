using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool doorKey;
    public bool open;
    [SerializeField] bool close;
    public bool inTrigger;
    public ItemContainer itemContainer;
    [SerializeField] Item screwDriver;
    [SerializeField] Item gluedcoin;
    [SerializeField] BoxCollider boxy;
    private bool glueGone;
    public MeshRenderer PLS;

    private void Start()
    {
        close = true;
    }

    //Checks if player entered 
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    //Checks if player exited
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    public void glueGones()
    {
        glueGone = true;
    }

    private void Update()
    {
        //if the player is close to the door
        if (inTrigger)
        {
            //if the door is closed
            if (close)
            {
                //if the player has the key
                if (itemContainer.ContainsItem(screwDriver) || itemContainer.ContainsItem(gluedcoin))
                {
                    //if the player presses E
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PLS.enabled = false;
                        boxy.enabled = false;
                        close = false;
                        open = true;
                    }
                }
                //no key
                else
                {

                    GameFeedback.Instance.SetText("Door is Locked");
                }
            }


        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                close = true;
                open = false;
            }
        }
    }
}

        
    

