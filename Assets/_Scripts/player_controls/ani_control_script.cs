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

		bool boolper = anim.GetBool("isIdle");
		anim.SetBool ("isIdle", !boolper);
		anim.SetBool ("isRun", false);
	}

	public void Run ()
	{

		bool boolper = anim.GetBool("isRun");
		anim.SetBool ("isRun", !boolper);
		anim.SetBool ("isIdle", false);
	}
}
