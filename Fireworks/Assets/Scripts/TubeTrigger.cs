using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTrigger : MonoBehaviour {
	// Thing that can be ctivated by player to trigger triggerables
	public GameObject icon;
	private GameObject icon_instance;
	public Vector3 iconpos;
	public Triggerable[] totrigger; // Thing that will be triggered
	public AudioClip[] sounds;
	private Animator anim;
	private AudioSource asource;

	private bool selected = false; // player is on top of this

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		asource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			if (Input.GetKeyDown (KeyCode.E)) {
				foreach ( Triggerable t in totrigger) t.trigger ();
				anim.SetTrigger ("activated");
				asource.clip = sounds [Random.Range ((int)0, sounds.Length)];
				asource.Play ();
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
