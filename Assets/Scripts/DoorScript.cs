using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public  bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;
    public ItemContainer itemContainer;
    [SerializeField] Item screwDriver;
    private bool glueGone;


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
                if (itemContainer.ContainsItem(screwDriver))
                {
                    //if the player presses E
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            { // if its closed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
            if (open)
            {
                //Closes the door
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
            else
            {
                //oopens the door
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }

        }
        
        }
        //Messages telling the player what to do
        private void OnGUI()
        {
            if (inTrigger)
            {
                if (open)
                {
                    GUI.Box(new Rect(0, 460, 200, 25), "Press E to close");
                }
                else
                {
                    if (doorKey)
                    {
                        GUI.Box(new Rect(0, 460, 200, 25), "Press E to open");
                    }
                    else
                    {
                        GUI.Box(new Rect(0, 460, 200, 25), "Need The Key");
                    }
                }
            }
        }
    }

