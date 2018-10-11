using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ani_control_script : MonoBehaviour {

	private Animator anim;

	void Awake ()
	{
		anim = GetComponentInChildren<Animator>();
	}

	public void Idle ()
	{
		anim.SetFloat("jump", -5f);
		anim.SetBool ("isIdle", true);
		anim.SetBool ("isRun", false);
	}

	public void Run ()
	{
		anim.SetBool ("isRun", true);
		anim.SetBool ("isIdle", false);
	}

	public void Pickup () {
		anim.SetTrigger ("isPickuping");
	}

	public void Wave () {
		anim.SetTrigger ("isWaving");
	}

	public void Jump (float Yvelocity) {
		anim.SetBool ("isIdle", false);
		anim.SetBool ("isRun", false);
		anim.SetFloat("jump", Yvelocity);
	}
}
