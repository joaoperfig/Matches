using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Counter counter;
	public MatchBox matchbox;
	public int matchesleft; // Some levels use multiple matches;

	// Use this for initialization
	void Start () {
		counter.setValue (matchesleft);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void matchDie() {
		if (matchesleft == 0) {
		} else {
			matchesleft -= 1;
			counter.setValue (matchesleft);
			matchbox.makeMatch ();
		}
	}
}
