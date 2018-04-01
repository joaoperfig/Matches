using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAfter : MonoBehaviour {

	public float solidtime;
	public float fadetime;

	private SpriteRenderer renderer;
	private Color startColor;
	private float start;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		startColor = renderer.color;
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > start + solidtime) {
			if (Time.time > start + solidtime + fadetime)
				renderer.color = new Color (0, 0, 0, 0);
			else {
				renderer.color = new Color (startColor.r, startColor.g, startColor.b, 1 - ((Time.time - (start + solidtime)) / fadetime));
			}
		}
	}
}
