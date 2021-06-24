using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    private SlidingPuzzle puzzle;
    private bool movedChair;
    private float speed;
    public Vector3 moveDirection;
    public GameObject oldChair;
    public Transform newChair;
    public GameObject blueprint;
    public GameObject chest;
    public GameObject firstCoinIcon;
    public GameObject firstCoinIcon1;
    public GameObject phoneIcon;
    public GameObject glueIcon;
    public GameObject cageScreen;
    public GameObject glue;
    public bool inside;
    private string item;
    public bool isPhone;
    public bool isChest;
    private bool isToys;
    private bool doneToys;
    private bool open;
    private bool isCoin1;
    private bool isCoin2;

    //checks if player enters
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            item = this.transform.parent.gameObject.tag;
            Debug.Log("Can Interact with: " + item);
        }
    }

    //checks if player exits
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = false;
            isChest = false;
            Debug.Log("Left range of " + item);
        }
    }

    private void ifPhone()
    {
        // the player picks it up the phone
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {

            //if the object is a phone
            if (item == "Phone")
            {
                Debug.Log("Player picked up the phone");
                //add to UI 
                isPhone = true;
                phoneIcon.gameObject.SetActive(true);

                //destroy the object
                Destroy(transform.parent.gameObject);
            }
        }
    }


    private void ifRope()
    {
        // the player picks it up the rope
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {

            //if the object is rope
            if (item == "Rope" || item == "Screwdriver" || item == "Magnet" )
            {
                Debug.Log("Player picked up the: " + item);
                //destroy the object
                Destroy(transform.parent.gameObject);
            }
        }
    }
    
    private void ifBlueprint()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {
            if (item == "Blueprint")
            {
                Debug.Log("Player picked up the: " + item);
                blueprint.SetActive(true);
            }
        }
    }

    private void ifChest()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {
            Debug.Log("!");
            if (item == "Chest")
            {
                Debug.Log("2");
               
                    if (isToys != true)
                    {
                        Debug.Log("CHest");
                        isToys = true;
                        //chest.SetActive(true);
                        //show puzzle
                        isChest = true;
                    }
                    else
                    {
                        chest.SetActive(false);
                        isToys = false;
                    }
                
            }
        }
    }

    private void ifCage()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {
            if(open != true)
            {
                if (item == "Cage")
                {
                    Debug.Log("Player picked up the: " + item);
                    cageScreen.SetActive(true);
                    open = true;
                }
            } else
            {
                cageScreen.SetActive(false);
                open = false;
            }
            
        }
    }

    private void ifChair()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {
            if (item == "Chair")
            {
                if (movedChair == false && movedChair == false)
                {
                    Debug.Log("ChairMove");
                    moveDirection = new Vector3(-2.5f, 0, 0.6f);
                    oldChair.transform.position += moveDirection;
                    movedChair = true;
                }
                else
                {

                }

            }
        }
    }

    private void ifGlue()
    {
        if(Input.GetKeyDown(KeyCode.F) && inside == true)
        {
            if(item == "Glue")
            {
                if (open == false)
                {
                    glue.SetActive(true);
                    open = true;
                }
                else
                {
                    glue.SetActive(false);
                    open = false;
                }
            }
        }
    }

    public void Finished()
    {
        chest.SetActive(false);
        isChest = true;

    }

    public void doneGlue()
    {
        glue.SetActive(false);
        glueIcon.SetActive(true);
    }
    private void ifCoin()
    {
        if (inside)
        {
            isCoin1 = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (item == "Coin")
                {
                    firstCoinIcon.SetActive(true);

                    //destroy the object
                    Destroy(transform.parent.gameObject);
                }
            }
        }
        
    }
    private void ifCoin1()
    {
        
    }

    public bool inChest()
    {
        return isChest;
    }
    private void Update()
    {
        ifPhone();
        ifChest();
        ifRope();
        ifChair();
        ifGlue();
        ifCoin();
        ifCoin1();
        ifCage();
    }


    private void OnGUI()
    {
        if (inside == true)
        {
            if (isPhone || isCoin1 || isCoin2)
            {
                GUI.Box(new Rect(0, 460, 200, 25), "Press F to PickUp");
            }
            if (isChest)
            {
                GUI.Box(new Rect(0, 460, 200, 25), "Press F to Open");
            }
        }
    }

    public bool DestroyedPhone()
    {
        return isPhone;
    }

}
