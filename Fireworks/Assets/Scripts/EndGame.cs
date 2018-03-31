using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public float duration;
	private float start;

	// Use this for initialization
	void Start () {
		start = Time.time; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > start + duration) {
			Destroy (GameObject.Find ("Music"));
			SceneManager.LoadScene ("main_menu");
		}
	}
}
