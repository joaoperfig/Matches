using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) || Input.GetMouseButtonDown (0))
			SceneManager.LoadScene ("level_1");
		
	}
}
