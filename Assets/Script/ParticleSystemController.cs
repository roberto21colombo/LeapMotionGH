using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleSystemController: MonoBehaviour {

	private bool start = false;

	private ParticleSystem mps;
	private GameObject bottle;

	public AudioSource clipWater;

	// Use this for initialization
	void Start () {

		mps = GetComponent<ParticleSystem> ();
		bottle = GameObject.FindGameObjectWithTag ("Bottle");
		mps.enableEmission = false;
		mps.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			start = true;
		}

		if (start) {
			if (bottle.transform.rotation.z < -0.75 || bottle.transform.rotation.z > 0.75) {
				if (!mps.emission.enabled) {
					mps.enableEmission = true;
					clipWater.Play ();
				}
			} else {
				if (mps.emission.enabled) {
					mps.enableEmission = false;
					clipWater.Stop ();
					Debug.Log ("Termina il suono!");
				}
			}
		}
	}
}
