using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class LMRotateObject : MonoBehaviour {
	Controller controller;
	float angle;

	public GameObject somethingToRotate;
	// Use this for initialization
	void Start () {
		controller = new Controller();
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();

		angle = 0;
		if (frame.Hands.Count > 0) {

			Hand mainHand = frame.Hands [0];
			Vector PalmNormal = mainHand.PalmNormal;
			angle = Vector3.Angle (new Vector3(PalmNormal.x, PalmNormal.y, 0), Vector3.down);

			if (PalmNormal.x < 0) {
				angle = angle * -1;
				angle = angle * 3/2;
			} else {
				angle = angle * 3;
			}
			somethingToRotate.transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		//Debug.Log (angle);
	}
}
