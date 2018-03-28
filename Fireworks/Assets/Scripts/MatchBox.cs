using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBox : MonoBehaviour {

	public GameObject match; // Match template to spawn
	public Vector3 deltaspawn; // Position where new match spawns

	private Animator anim;
	private bool isbirthing = false;
	private float maketime;
	private AudioSource asource;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		asource = gameObject.GetComponent<AudioSource> ();
		makeMatch ();
	}

	// Update is called once per frame
	void Update () {
		if (isbirthing) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idle") && Time.time > maketime+0.02) {
				Debug.Log ("newmatch");
				GameObject.Instantiate (match, gameObject.transform.position + deltaspawn, Quaternion.identity);
				isbirthing = false;
			}
		}
	}

	public void makeMatch(){ 
		isbirthing = true;
		anim.SetTrigger ("birth");
		asource.Play ();
		maketime = Time.time; // Prevents match spawning because update was called before animation trigger was processed
	}
}
