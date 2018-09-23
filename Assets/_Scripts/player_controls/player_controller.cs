using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	private Animator animator;
	private ani_control_script animationControl;
	private CharacterController charController;
	private float speed;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animationControl = GetComponent<ani_control_script>();
		charController = GetComponent<CharacterController>();
		speed = 0.1f;
	}
	
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        charController.Move(movement * speed);
        if (charController.velocity == Vector3.zero && !animator.GetBool("isIdle"))
        {
        	animationControl.Idle();           
        }

        if (charController.velocity != Vector3.zero && !animator.GetBool("isRun"))
        {
        	animationControl.Run();
	    	transform.rotation = Quaternion.LookRotation (movement * speed);

        }

    }
}
