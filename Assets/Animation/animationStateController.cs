using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool upPressed = Input.GetKey("space");
        // if player presses w key
        if (forwardPressed)
        {
            // then set the isWalking boolean to be true
            animator.SetBool("isWalking", true);
        }

        if (!forwardPressed)
        {
            // then set the isWalking boolean to be false
            animator.SetBool("isWalking", false);
        }

        // if player presses spacebar 
        if (upPressed)
        {

            // then set the isJumping boolean to be true
            animator.SetBool("isJumping", true);
        }

        if (!upPressed) 
        {

            // then set the isJumping boolean to be false
            animator.SetBool("isJumping", false);
        }

        // if player presses a key 
        if (leftPressed)
        {

            // then set the isTurningLeft boolean to be true
            animator.SetBool("isTurningLeft", true);
        }

        if ((!leftPressed) || (forwardPressed && leftPressed))
        {

            // then set the isTurningLeft boolean to be false
            animator.SetBool("isTurningLeft", false);
        }

        // if player presses d key 
        if (rightPressed)
        {

            // then set the isTurningRight boolean to be true
            animator.SetBool("isTurningRight", true);
        }

        if ((!rightPressed) || (forwardPressed && rightPressed))
        {

            // then set the isTurningRight boolean to be false
            animator.SetBool("isTurningRight", false);
        }
    }
}
