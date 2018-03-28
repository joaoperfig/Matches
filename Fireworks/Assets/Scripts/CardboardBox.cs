using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBox : Explodable {

	private Animator anim;
	private bool dying = false;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (dying && anim.GetCurrentAnimatorStateInfo (0).IsTag ("end")) {
			Destroy (gameObject);
		}
	}

	public override void activate() {
		anim.SetTrigger ("activate");
		dying = true;
	}
}
