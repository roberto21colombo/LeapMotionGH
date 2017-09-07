using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController: MonoBehaviour {

	public int countWaterLeft = 500;
	int countWaterRed = 500;
	int countWaterBlue = 500;

	public GameObject barWaterRed;
	public GameObject barWaterBlue;
	public GameObject barWaterLeft;

	private bool start = false;

	private ParticleSystem mps;

	// Use this for initialization
	void Start () {
		drawBar();
		mps = GetComponent<ParticleSystem> ();
		mps.enableEmission = false;
		mps.Play ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other){
		if(other.tag.Equals("Plane") && countWaterLeft > 0){
			countWaterLeft--;
		}
		if(other.tag.Equals("VaseRed") && countWaterRed > 0){
			Debug.Log ("Hai colpito Vase Red");
			countWaterRed--;
		}
		if(other.tag.Equals("VaseBlue") && countWaterBlue > 0){
			Debug.Log ("Hai colpito Vase Blue");
			countWaterBlue--;
		}
		if(mps.isEmitting){
		}
		drawBar ();
	}

	void drawBar(){

//		Debug.Log ("R:"+countWaterRed+", B:"+countWaterBlue+", L:"+countWaterLeft);

		barWaterRed.transform.localScale = new Vector3 (1,0,1);
		barWaterBlue.transform.localScale = new Vector3 (1,0,1);
		barWaterLeft.transform.localScale = new Vector3 (1,0,1);

		for (int i = 0; i < countWaterLeft; i=i+5){
			barWaterLeft.transform.localScale += new Vector3 (0,1,0);
		}
		for (int i = 0; i < countWaterRed; i=i+5){
			barWaterRed.transform.localScale += new Vector3 (0,1,0);
		}
		for (int i = 0; i < countWaterBlue; i=i+5){
			barWaterBlue.transform.localScale += new Vector3 (0,1,0);
		}
			

	}
}
