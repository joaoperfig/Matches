using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {

	public float walkspeed;
	private Animator animator;
	private bool lit = false;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	public void setfire(){
		if (!lit) {
			lit = true;
			animator.SetTrigger ("burn");
		}
	}

	private void move(){
		Vector3 movement = new Vector3 (0, 0, 0);  // vector with movement direction
		if (Input.GetKey (KeyCode.A)) { // Player pressed left
			movement += new Vector3 (-1, 0, 0);
		}
		if (Input.GetKey (KeyCode.D)) { // Player pressed Right
			movement += new Vector3 (1, 0, 0);
		}
		if (movement.sqrMagnitude > 0) {
			if (movement.x < 0)
				gameObject.transform.localScale = new Vector3 (-2f, 2f, 2f);
			else
				gameObject.transform.localScale = new Vector3 (2f, 2f, 2f);
			animator.SetTrigger ("walk");
			movement.Normalize ();
			movement = movement * walkspeed * Time.deltaTime;
			gameObject.transform.position = gameObject.transform.position + movement;
		} else {
			animator.SetTrigger ("stop");
		} 

	}
}
