using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker : MonoBehaviour {

	public float maxdist;
	public float speed;
	public GameObject liftoff;
	private bool activated = false;
	private bool travelling = false;
	private Match triggerer; //knows whitch match triggered this to kill him;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (travelling) {
			float rotation = gameObject.transform.rotation.eulerAngles.z;
			Vector3 direction = new Vector3(-Mathf.Sin(Mathf.Deg2Rad*rotation), Mathf.Cos(Mathf.Deg2Rad*rotation), 0); // where the rocket is pointing
			gameObject.transform.position += direction.normalized * speed * Time.deltaTime;
		}
		else if (activated) { //activated but not yet travelling
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("travel")) {
				travelling = true;
				GameObject.Instantiate (liftoff, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	void activate(){
		activated = true;
		anim.SetBool ("active", true);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Match>().lit) {
			activate ();
			triggerer = other.gameObject.GetComponent<Match> ();
		}
	}
}
