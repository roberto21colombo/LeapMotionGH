using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LogicGame : MonoBehaviour {

	public GameObject imgDropRed;
	public GameObject imgDropBlue;
	public Text countDown;
	public bool isLeftWater = true;

	public int dropColor = -1;

	public int randomMinTime, randomMaxTime;
	public bool gameEnded = false;

	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		imgDropBlue.SetActive (false);
		imgDropRed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		int countWaterLeft = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterLeft;
		int countWaterRed = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterRed;
		int countWaterBlue = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterBlue;

		int maxWaterIn = GameObject.Find ("Particle System").GetComponent<ScoreController> ().maxWaterIn;
		int maxWaterOut = GameObject.Find ("Particle System").GetComponent<ScoreController> ().maxWaterOut;

		if(Input.GetKeyDown(KeyCode.Space)){
			imgDropBlue.SetActive (false);
			StartCoroutine("play");
		}

		if (isLeftWater && countWaterLeft == maxWaterOut || countWaterRed >= maxWaterIn  && countWaterBlue >= maxWaterIn ) {
			gameEnded = true;
			imgDropBlue.SetActive (false);
			imgDropRed.SetActive (false);
		}
	}

	IEnumerator play()
	{
		Debug.Log ("sono nel play");
		while (!gameEnded) {
			dropColor = dropColor * -1;
			drawDrop ();

			int timeRandom = Random.Range (randomMinTime, randomMaxTime);

			for(int i=0; i<timeRandom; i++){
				countDown.text = "" + (timeRandom - i) + "s";
				yield return new WaitForSeconds (1);
			}

		}
	}

	void drawDrop(){
		if (dropColor == -1) {
			imgDropBlue.SetActive (false);
			imgDropRed.SetActive (true);
		} else {
			imgDropRed.SetActive (false);
			imgDropBlue.SetActive (true);
		}
	}
}