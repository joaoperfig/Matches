using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

	public GameObject icon;
	private GameObject icon_instance;
	public Vector3 iconpos;
	public GameObject item;  // item that match will instantiate
	public string animtrigger; // animation trigger to call on Match animator (to make him do carry animation)
	private AudioSource asource;
	private bool selected = false;
	private Match player;

	// Use this for initialization
	void Start () {
		asource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			if (Input.GetKeyDown (KeyCode.E)) {
				selected = false;
				Destroy (icon_instance);
				asource.Play ();
				player.carry (item, animtrigger);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && !other.gameObject.GetComponent<Match>().iscarry) { // player cannot be carrying an item (would cause "E" conflicts)
			player = other.gameObject.GetComponent<Match> ();
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
