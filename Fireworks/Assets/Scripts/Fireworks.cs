﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

	// Script to choose random fireworks skin

	public int skin_number;
	public AudioClip[] effects;
	private Animator anim;
	private AudioSource asource;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		int skin = Random.Range ((int)1, skin_number+1);
		anim.SetTrigger (skin.ToString ());
		asource = gameObject.GetComponent<AudioSource> ();
		asource.clip = effects [Random.Range ((int)0, effects.Length)];
		asource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("end"))
			Destroy (gameObject);
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Rocket") {
			other.gameObject.GetComponent<Explodable> ().activate ();
		}
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Match> ().die ();
		}
	}
}
