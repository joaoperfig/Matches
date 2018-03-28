using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeFire :Triggerable {

	public bool active;
	private Animator anim;
	private AudioSource asource;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		asource = gameObject.GetComponent<AudioSource> ();
		anim.SetBool ("active", active);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void trigger() { // toggle active state and do appropriate animation
		active = !active;
		anim.SetBool ("active", active);
		if (active)
			asource.Play ();
		else
			asource.Pause ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			if (active) {
				other.gameObject.GetComponent<Match> ().setfire ();
			}
		}
	}
}
