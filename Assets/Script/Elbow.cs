using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Leap;

public class Elbow : MonoBehaviour {
	private Controller controller;
	private GameObject mouth;
	private bool happy;

	public Text elbowText;

	// Use this for initialization
	void Start () {
		elbowText.enabled = false;
		controller = new Controller();
		happy = true;
		mouth = GameObject.FindGameObjectWithTag ("Mouth");
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();

		if (frame.Hands.Count > 0) {
			Vector handPosition = frame.Hands [0].PalmPosition;
			Vector elbowPosition = frame.Hands [0].Arm.ElbowPosition;

			if (elbowPosition.y > handPosition.y) {
				elbowText.enabled = true;
				if (happy) {
					Debug.Log("Triste!!");
					mouth.transform.Rotate (new Vector3 (180, 0, 0));
					happy = false;
				}
			} else {
				elbowText.enabled = false;
				if (!happy) {
					Debug.Log("Felice!!");
					mouth.transform.Rotate (new Vector3 (-180, 0, 0));
					happy = true;
				}
			}
		}

	}
}
