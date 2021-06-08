using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherMovement : MonoBehaviour
{
    public float Speed = 3.0F;
    private float gravity = 20;
    public float RotateSpeed = 3.0F;
    public float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime, 0);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = Vector3.forward * Input.GetAxis("Vertical");
            // convert direction from local to global space:
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // convert velocity to displacement and move character:
        controller.Move(moveDirection * Time.deltaTime);
    }

}
