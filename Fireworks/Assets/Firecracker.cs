using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker : MonoBehaviour {

	public float maxdist;
	public float speed;

	private float activated = false;

	private Animator anim;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void activate(){
		activated = true;
		anim.SetTrigger ("activate");
	}
}
