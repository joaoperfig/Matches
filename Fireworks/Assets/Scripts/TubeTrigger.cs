using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTrigger : MonoBehaviour {

	public GameObject icon;
	private GameObject icon_instance;
	public Vector3 iconpos;
	public Triggerable totrigger; // Thing that will be triggered
	private Animator anim;

	private bool selected = false; // player is on top of this

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			if (Input.GetKeyDown (KeyCode.E)) {
				totrigger.trigger ();
				anim.SetTrigger ("activated");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			selected = true;
			icon_instance = GameObject.Instantiate (icon, gameObject.transform.position+iconpos, Quaternion.identity);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			selected = false;
			Destroy (icon_instance);
		}
	}
}
