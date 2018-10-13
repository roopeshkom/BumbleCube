using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    public float jumpPower;
    public float moveSpeed;
    public float turnSpeed;
    public float gravity;
    public float jumpForwardFactor;

    private ani_control_script animationControl;
    private CharacterController charController;
    private Vector3 movement;

    // Use this for initialization
    void Start()
    {
        animationControl = GetComponent<ani_control_script>();
        charController = GetComponent<CharacterController>();
        movement = Vector3.zero;
    }

    // Handles movements
    void FixedUpdate()
    {
        // Calculates instant ground movement when on ground, and applies gravity when in air
        if (charController.isGrounded)
        {
            movement = CalculateGroundMovement();
        }
        else
        {
            movement += Vector3.down * gravity;
        }

        charController.Move(movement * Time.deltaTime);
        transform.Rotate(Vector3.up * Mathf.Pow(Input.GetAxis("Horizontal"), 3) * turnSpeed * Time.deltaTime);
    }

    // Handles animation
    void Update()
    {
        SwitchAnimStates();
        FireAnims();
    }

    // Fires wave and pickup animations if on ground (Fire controls here)
    private void FireAnims()
    {
        if (Mathf.Abs(charController.velocity.z) > 0.01f)
        {
            animationControl.Run();
        }
        else
        {
            animationControl.Idle();
        }
    }

    // Handles animation switching between run and idle if not moving (Switch anim states here)
    private void SwitchAnimStates()
    {
        if (charController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animationControl.Pickup();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                animationControl.Wave();
            }
        }
    }

    // Calculates movement when character is on ground
    private Vector3 CalculateGroundMovement()
    {
        Vector3 ground_movement = transform.forward* Mathf.Pow(Input.GetAxis("Vertical"), 3) * moveSpeed;
        if (Input.GetButton("Jump"))
        {
            ground_movement += Vector3.Lerp(Vector3.up, transform.forward, jumpForwardFactor) * jumpPower;
        }

        return ground_movement;
    }

}
