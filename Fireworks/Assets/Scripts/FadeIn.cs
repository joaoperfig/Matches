using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	public float duration;
	public bool inverted;
	private float start;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		start = Time.time;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		renderer.color = new Color (0, 0, 0, 1);
		if (inverted) renderer.color = new Color (1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > start + duration) {
			renderer.color = new Color (0, 0, 0, 0);
			if (inverted)
				renderer.color = new Color (1, 1, 1, 1);
		} else {
			renderer.color = new Color (0, 0, 0, 1 - ((Time.time - start) / duration));
			if (inverted) renderer.color = new Color (1, 1, 1, ((Time.time - start) / duration));
		}
	}
}
