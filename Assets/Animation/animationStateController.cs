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
        // if player presses w key
        if (Input.GetKey("w"))
        {
            // then set the isWalking boolean to be true
            animator.SetBool("isWalking", true);
        }

        if (!Input.GetKey("w"))
        {
            // then set the isWalking boolean to be false
            animator.SetBool("isWalking", false);
        }

        // if player presses spacebar 
        if (Input.GetKey("space"))
        {

            // then set the isJumping boolean to be true
            animator.SetBool("isJumping", true);
        }

        if (!Input.GetKey("space")) 
        {

            // then set the isJumping boolean to be false
            animator.SetBool("isJumping", false);
        }

        // if player presses a key 
        if (Input.GetKey("a"))
        {

            // then set the isTurningLeft boolean to be true
            animator.SetBool("isTurningLeft", true);
        }

        if (!Input.GetKey("a"))
        {

            // then set the isTurningLeft boolean to be false
            animator.SetBool("isTurningLeft", false);
        }

        // if player presses d key 
        if (Input.GetKey("d"))
        {

            // then set the isTurningRight boolean to be true
            animator.SetBool("isTurningRight", true);
        }

        if (!Input.GetKey("d"))
        {

            // then set the isTurningRight boolean to be false
            animator.SetBool("isTurningRight", false);
        }
    }
}
