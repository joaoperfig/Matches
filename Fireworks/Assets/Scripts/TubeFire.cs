using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeFire :Triggerable {

	private bool active = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void trigger() { // toggle active state and do appropriate animation
		active = !active;
		anim.SetBool ("active", active);
	}
}
