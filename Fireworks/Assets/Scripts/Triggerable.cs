using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour {
	// Class of gameobjects that can be triggered by ingame buttons
	public abstract void trigger ();
}
