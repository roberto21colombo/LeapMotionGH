using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFollaScript : MonoBehaviour {
	private AudioSource folla;

	// Use this for initialization
	void Start () {
		folla = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			folla.Stop ();
		}
		if (GameObject.Find ("Canvas").GetComponent<LogicGame> ().gameEnded || Input.GetKeyDown(KeyCode.S)) {
			folla.Play ();
		}
	}
}
