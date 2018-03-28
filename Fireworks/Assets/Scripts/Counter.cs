using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

	public Sprite[] numbers;
	public int value;

	void Start() {
		setValue (value);
	}

	public void setValue (int newval) {
		value = newval;
		gameObject.GetComponent<SpriteRenderer> ().sprite = numbers [value];
	}
}
