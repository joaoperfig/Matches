using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMachine : Triggerable {

	public override void trigger() {
		gameObject.GetComponent<Animator> ().SetTrigger ("activate");
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
