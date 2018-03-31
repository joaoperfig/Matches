using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableWall : Triggerable {

	public bool isup;  // Is the wall up
	private Animator anim;
	private AudioSource asource;
	private BoxCollider2D collider;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		asource = gameObject.GetComponent<AudioSource> ();
		collider = gameObject.GetComponent<BoxCollider2D> ();
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		updateStatus ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void trigger() {
		isup = !isup;
		updateStatus ();
		asource.Play ();
	}

	void updateStatus() {  // turn to appropriate animation state and collider state
		anim.SetBool ("isup", isup);
		collider.isTrigger = !isup; // if wall is up, then the collider is not a trigger
		if (isup)
			renderer.sortingLayerName = "OverMatch";
		else
			renderer.sortingLayerName = "UnderMatch";

	}
}
