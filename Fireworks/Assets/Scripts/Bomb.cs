using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Explodable {

	private bool activated = false;
	private bool exploded = false;
	private Animator anim;
	public GameObject fireworks;
	private AudioSource asource;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("active", activated);
		asource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activated && anim.GetCurrentAnimatorStateInfo (0).IsTag ("explode") && !exploded)
			explode ();
		if (activated && anim.GetCurrentAnimatorStateInfo (0).IsTag ("end"))
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Match>().lit) {
			activate ();
		}
	}

	public override void activate(){
		activated = true;
		anim.SetBool ("active", true);
		asource.Play ();
	}

	public void explode() {
		GameObject.Instantiate (fireworks, gameObject.transform.position, Quaternion.identity);
		exploded = true;
	}
}
