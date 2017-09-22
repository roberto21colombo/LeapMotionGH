using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController: MonoBehaviour {

	//Valori particelle iniziali
	public int countWaterLeft = 0;
	public int countWaterRed = 0;
	public int countWaterBlue = 0;
	public int maxWaterIn = 500;
	public int maxWaterOut = 1000;
	public int speed = 1;

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

		GameObject.Find ("TopBarRed").transform.localScale = new Vector3 (1, maxWaterIn/10,1);
		GameObject.Find ("TopBarBlue").transform.localScale = new Vector3 (1, maxWaterIn/10,1);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other){
		int dropColor = GameObject.Find ("Canvas").GetComponent<LogicGame> ().dropColor;
		//Controllo collisioni Piano e Contenitori
		if(other.tag.Equals("Plane") && countWaterLeft < maxWaterOut){
			countWaterLeft++;
		}
		if(other.tag.Equals("VaseRed") && countWaterRed <= maxWaterIn){
			if (dropColor == -1) {
				countWaterRed += speed;
			} else {
				countWaterRed -= speed;
			}
		}
		if(other.tag.Equals("VaseBlue") && countWaterBlue <= maxWaterIn){
			if (dropColor == 1) {
				countWaterBlue += speed;
			} else {
				countWaterBlue -= speed;
			}
		}
		drawBar ();
	}

	void drawBar(){

//		Debug.Log ("R:"+countWaterRed+", B:"+countWaterBlue+", L:"+countWaterLeft);
		//
		barWaterRed.transform.localScale = new Vector3 (1,0,1);
		barWaterBlue.transform.localScale = new Vector3 (1,0,1);
		barWaterLeft.transform.localScale = new Vector3 (1,0,1);

		for (int i = 0; i < countWaterLeft; i=i+10){
			barWaterLeft.transform.localScale += new Vector3 (0,1,0);
		}
		for (int i = 0; i < countWaterRed; i=i+10){
			barWaterRed.transform.localScale += new Vector3 (0,1,0);
		}
		for (int i = 0; i < countWaterBlue; i=i+10){
			barWaterBlue.transform.localScale += new Vector3 (0,1,0);
		}
			

	}
}
