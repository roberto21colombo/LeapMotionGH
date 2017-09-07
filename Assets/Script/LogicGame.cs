using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGame : MonoBehaviour {

	public GameObject dropRed;
	public GameObject dropBlue;
	public GameObject elbow;

	private int dropColor = -1;
	private bool gameEnded = false;

	// Use this for initialization
	void Start () {
		StartCoroutine("play");
	}
	
	// Update is called once per frame
	void Update () {
		int countWaterLeft = GameObject.Find ("Particle System").GetComponent<ScoreController> ().countWaterLeft;
		if (countWaterLeft == 0) {
			gameEnded = true;
			dropBlue.SetActive (false);
			dropRed.SetActive (false);
		}
	}

	IEnumerator play()
	{
		while (!gameEnded) {
			dropColor = dropColor * -1;
			drawDrop ();

			int timeRandom = Random.Range (3, 10);
			Debug.Log (timeRandom);
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