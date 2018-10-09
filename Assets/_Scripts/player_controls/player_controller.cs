using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	private Animator animator;
	private ani_control_script animationControl;
	private CharacterController charController;
	private float gravity = 0;
	private float speed;
	private bool isGrounded;

    private readonly float m_interpolation = 10;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animationControl = GetComponent<ani_control_script>();
		charController = GetComponent<CharacterController>();
		speed = 0.1f;
		isGrounded = true;
	}
	
    void FixedUpdate () {    	
    	 gravity -= 9.81f * Time.deltaTime;

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");


        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Vector3 gravityV = new Vector3(0f, gravity, 0f);
        transform.rotation = Quaternion.LookRotation (movement * speed);
        charController.Move((movement + gravityV) * speed);
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

    // private void TankUpdate() {
    //     float v = Input.GetAxis("Vertical");
    //     float h = Input.GetAxis("Horizontal");

    //     bool walk = Input.GetKey(KeyCode.LeftShift);

    //     if (v < 0) {
    //         if (walk) { v *= m_backwardsWalkScale; }
    //         else { v *= m_backwardRunScale; }
    //     } else if(walk)
    //     {
    //         v *= m_walkScale;
    //     }

    //     float m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
    //     float m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

    //     transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
    //     transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

    //     animator.SetFloat("MoveSpeed", m_currentV);

    //     JumpingAndLanding();
    // }

    // private void JumpingAndLanding() {
    //     bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

    //     if (jumpCooldownOver && isGrounded && Input.GetKey(KeyCode.Space))
    //     {
    //         m_jumpTimeStamp = Time.time;
    //         m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
    //     }

    //     if (!wasGrounded && isGrounded)
    //     {
    //         m_animator.SetTrigger("Land");
    //     }

    //     if (!isGrounded && wasGrounded)
    //     {
    //         animator.SetTrigger("Jump");
    //     }
    // }

}
