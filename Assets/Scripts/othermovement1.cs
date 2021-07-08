using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othermovement1 : MonoBehaviour
{
    public float Speed = 3.0F;
    private float slowSpeed;
    private float originalSpeed;
    private float gravity = 20;
    public float RotateSpeed = 3.0F;
    public float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        originalSpeed = Speed;
        slowSpeed = Speed * 0.2f;
    }
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
    private void OnEnable()
    {
        this.gameObject.GetComponent<othermovement1>().enabled = true;
    }
    public void SmallSpeed()
    {
        Speed = slowSpeed;
    }
    public void bigSpeed()
    {
        Speed = originalSpeed;
    }


}
