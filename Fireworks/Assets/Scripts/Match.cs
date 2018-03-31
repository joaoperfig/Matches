using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {

	public float walkspeed;
	public GameObject dead;
	private Animator animator;
	private AudioSource asource;
	public AudioClip burn;
	public AudioClip place;
	public bool lit = false;

	public bool iscarry = false;
	private bool ereleased; // ensures that the player must release E before clicking it to instantiate
	private GameObject toplace; // object being carried
	public GameObject placeicon; // icon to place item
	private GameObject icon_instance;
	public Vector3 iconpos; //distance to icon
	public Vector3 itempos; //distance to instantiated items
	public GameObject fireworks; // for if the player grabs an item while on fire

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		asource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		if (Input.GetKeyUp (KeyCode.E))
			ereleased = true;
		if (iscarry)
			icon_instance.transform.position = gameObject.transform.position + iconpos;  //icon hovers player
		if (iscarry && lit)
			GameObject.Instantiate (fireworks, gameObject.transform.position, Quaternion.identity);  // explode if carrying while lit
		if (iscarry && ereleased && Input.GetKeyDown (KeyCode.E)) {
			asource.clip = place;
			asource.Play ();
			iscarry = false;
			animator.SetTrigger ("drop");
			Destroy (icon_instance);
			GameObject.Instantiate (toplace, gameObject.transform.position + itempos, Quaternion.identity);
		}
	}

	public void setfire(){
		if (!lit) {
			lit = true;
			animator.SetTrigger ("burn");
			asource.clip = burn;
			asource.Play ();
		}
	}

	private void move(){
		Vector3 movement = new Vector3 (0, 0, 0);  // vector with movement direction
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) { // Player pressed left
			movement += new Vector3 (-1, 0, 0);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) { // Player pressed Right
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

	public void die(){
		GameObject.Instantiate (dead, gameObject.transform.position, Quaternion.identity);
		GameObject.Find ("GameManager").GetComponent<GameManager> ().matchDie ();
		if (iscarry)
			Destroy (icon_instance);
		Destroy (gameObject);
	}

	public void carry(GameObject instance, string animtrigger) {
		ereleased = false; // player is pressing on E and must release it before dropping item
		iscarry = true;
		toplace = instance;
		animator.SetTrigger (animtrigger);
		icon_instance = GameObject.Instantiate (placeicon, gameObject.transform.position + iconpos, Quaternion.identity);
	}
}
