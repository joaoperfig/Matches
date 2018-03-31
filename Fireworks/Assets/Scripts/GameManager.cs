using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	// Manager of a single level
	public Counter counter;
	public MatchBox matchbox;
	public GameObject bigrestart;
	public int matchesleft; // Some levels use multiple matches;
	public int nextlevel;

	// Use this for initialization
	void Start () {
		counter.setValue (matchesleft);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void matchDie() {
		if (matchesleft == 0) {
			GameObject.Instantiate (bigrestart);
		} else {
			matchesleft -= 1;
			counter.setValue (matchesleft);
			matchbox.makeMatch ();
		}
	}

	public void win () {
		Debug.Log ("yay");
		SceneManager.LoadScene ("level_" + nextlevel.ToString ());
	}
}
