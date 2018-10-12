using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

    public float jumpPower;
    public float moveSpeed;
    public float turnSpeed;
    public float gravity;
    public float jumpForwardFactor;

    private ani_control_script animationControl;
	private CharacterController charController;
    private Vector3 movement;
	
	// Use this for initialization
	void Start () {
		animationControl = GetComponent<ani_control_script>();
		charController = GetComponent<CharacterController>();
        movement = Vector3.zero;
	}
	
    void FixedUpdate () {

        // Rotates and moves the player, and factors in gravity and jumping, scaled with movement (Control movements here)
        if (charController.isGrounded) {
            movement = transform.forward * Mathf.Pow(Input.GetAxis("Vertical"), 3) * moveSpeed * Time.deltaTime;
            if (Input.GetButton("Jump")) {
                movement += Vector3.Lerp(Vector3.up, transform.forward, jumpForwardFactor) * jumpPower * Time.deltaTime;
            }
        }else{
            movement += Vector3.down * gravity * Time.deltaTime;
        }

        charController.Move(movement);
        transform.Rotate(Vector3.up * Mathf.Pow(Input.GetAxis("Horizontal"), 3) * turnSpeed * Time.deltaTime);
    }

    void Update() {

        // Handles animation switching between run and idle if not moving (Switch anim states here)
        if (Mathf.Abs(charController.velocity.z) > 0.01f) {
            animationControl.Run();
        } else {
            animationControl.Idle();
        }

        // Fires wave and pickup animations if on ground (Fire controls here)
        if (charController.isGrounded) {
            if (Input.GetButton("Fire1")) {
                animationControl.Pickup();
            }

            if (Input.GetButton("Fire2")) {
                animationControl.Wave();
            }
        }

    }

}
