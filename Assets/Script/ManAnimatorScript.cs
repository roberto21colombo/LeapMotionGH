using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnimatorScript : MonoBehaviour {

	Animator anim;
	//private bool start = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.Play ("Armature|PlayLoop");
		}


		if (GameObject.Find ("Canvas").GetComponent<LogicGame> ().gameEnded || Input.GetKeyDown(KeyCode.S)) {
			anim.Play ("Armature|Final");
		}
	}
}
