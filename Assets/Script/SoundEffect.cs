using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {
	private AudioSource clipWater;

	public ParticleSystem PSWater;

	// Use this for initialization
	void Start () {
		clipWater = GetComponent<AudioSource> ();
		clipWater.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other){
		Debug.Log ("Collisione x suono");
		if (other.tag.Equals ("Plane") || other.tag.Equals ("VaseRed") || other.tag.Equals ("VaseBlue")) {
			if (!clipWater.isPlaying) {
				clipWater.Play ();
				Debug.Log ("Inizia il suono!");
			}
		} else {
			clipWater.Stop ();
			Debug.Log ("Termina il suono!");
		}

	}
}
