using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	private ani_control_script animationControl;
	private CharacterController charController;
	private float gravity = 10f;
	private float jumpSpeed = 4.5f;
	private float speed = 1.5f;
	private bool isJumping = false;
	private bool isActionFired = false;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		animationControl = GetComponent<ani_control_script>();
		charController = GetComponent<CharacterController>();
	}
	
    void FixedUpdate () {
        if (charController.isGrounded) {
        	isJumping = false;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                isJumping = true;
                moveDirection.y = jumpSpeed;
            } else if (Input.GetButton("Fire1")) {
            	animationControl.Pickup();
           	} else if (Input.GetButton("Fire2")) {
           		animationControl.Wave();
           	}
        }
        if (isJumping) {
        	moveDirection.y -= gravity * Time.deltaTime;
        	animationControl.Jump(moveDirection.y);
        } else {
	        moveDirection.y -= gravity;
        }
        charController.Move(moveDirection * Time.deltaTime);

        Vector3 turnAngle = new Vector3(charController.velocity.x, 0f, charController.velocity.z);
        if (turnAngle != Vector3.zero) {
        	animationControl.Run();
        	transform.rotation = Quaternion.LookRotation(turnAngle * Time.deltaTime);
        } else {
        	animationControl.Idle();
        }
        
      //   if (charController.velocity == Vector3.zero && !animator.GetBool("isIdle"))
      //   {
      //   	animationControl.Idle();           
      //   }

      //   if (charController.velocity != Vector3.zero && !animator.GetBool("isRun"))
      //   {
      //   	animationControl.Run();
	    	// transform.rotation = Quaternion.LookRotation (movement * speed);

      //   }
    }

}
