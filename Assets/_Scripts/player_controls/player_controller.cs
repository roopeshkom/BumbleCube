using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	private Animator animator;
	private ani_control_script animationControl;
	private CharacterController charController;
	private float gravity = 10f;
	private float jumpSpeed = 4.7f;
	private float speed = 1.5f;
	private bool isJumping = false;
	private Vector3 moveDirection = Vector3.zero;
	private float t = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
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
                t = 0;
            }
        }
        if (isJumping) {
        	moveDirection.y = jumpSpeed - gravity * t;
        	t += Time.deltaTime;
        } else {
	        moveDirection.y -= gravity;
        }
        charController.Move(moveDirection * Time.deltaTime);
        
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
