using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LogicGame : MonoBehaviour {

	public GameObject dropRed;
	public GameObject dropBlue;
	public Text countDown;
	public bool isLeftWater = true;

	public int dropColor = -1;

	public int randomMinTime, randomMaxTime;
	public bool gameEnded = false;

	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		dropBlue.SetActive (false);
		dropRed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		int countWaterLeft = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterLeft;
		int countWaterRed = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterRed;
		int countWaterBlue = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterBlue;

		if(Input.GetKeyDown(KeyCode.Space)){
			dropBlue.SetActive (false);
			StartCoroutine("play");
		}

		if (isLeftWater && countWaterLeft== 0 || countWaterRed == 0 && countWaterBlue == 0 ) {
			gameEnded = true;
			dropBlue.SetActive (false);
			dropRed.SetActive (false);
		}
	}

	IEnumerator play()
	{
		Debug.Log ("sono nel play");
		while (!gameEnded) {
			dropColor = dropColor * -1;
			drawDrop ();

			int timeRandom = Random.Range (randomMinTime, randomMaxTime);
			countDown.text = "" + timeRandom + "s";
			yield return new WaitForSeconds (timeRandom);
		}
	}

	void drawDrop(){
		if (dropColor == -1) {
			dropBlue.SetActive (false);
			dropRed.SetActive (true);
		} else {
			dropRed.SetActive (false);
			dropBlue.SetActive (true);
		}
	}
}