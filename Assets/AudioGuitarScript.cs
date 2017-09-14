using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGuitarScript : MonoBehaviour {

	private AudioSource guitar;

	// Use this for initialization
	void Start () {
		guitar = GetComponent<AudioSource> ();
		guitar.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			guitar.Play ();
		}

		if (GameObject.Find ("Canvas").GetComponent<LogicGame> ().gameEnded || Input.GetKeyDown(KeyCode.S)) {
			guitar.Stop ();
		}
	}
}
