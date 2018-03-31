using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeExit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			GameManager manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			manager.win ();
		}
	}
}
