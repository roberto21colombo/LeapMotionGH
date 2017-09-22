using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LMRotateObject : MonoBehaviour {
	Controller controller;
	public float sensEasyRot = 1.5f;
	public float sensHardRot = 3f;

	private GameObject somethingToRotate;
	// Use this for initialization
	void Start () {
		controller = new Controller();
		somethingToRotate = GameObject.FindGameObjectWithTag ("Bottle");
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();

		float angle = 0;
		if (frame.Hands.Count > 0) {

			Hand mainHand = frame.Hands [0];
			Vector PalmNormal = mainHand.PalmNormal;
			angle = Vector3.Angle (new Vector3(PalmNormal.x, PalmNormal.y, 0), Vector3.down);

			//Sto usando la mano destra?
			if (mainHand.IsRight) {
				//Sto ruotando la mano destra a destra?
				if (PalmNormal.x < 0) {
					angle = angle * -1;
					angle = angle * sensEasyRot;
				} else {
					angle = angle * sensHardRot;
				}
				somethingToRotate.transform.rotation = Quaternion.Euler (0, 0, angle);
			} else {
				if (PalmNormal.x < 0) {
					angle = angle * -1;
					angle = angle * sensHardRot;
				} else {
					angle = angle * sensEasyRot;
				}
				somethingToRotate.transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}
		//Debug.Log (angle);
	}
}
