using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* First of all we need to import Leap Motion Controller Library */
using Leap;

public class FollowHand : MonoBehaviour {
	Controller controller;

	private GameObject somethingToMove;

	void Awake (){
		/* Create a new controller: 									 				*
	 * The controller class allow us to access data from the leap motion controller */
		controller = new Controller();
		somethingToMove = GameObject.FindGameObjectWithTag ("Bottle");
	}

	void Update ()
	{
		/* A controller produces frame at a certain frame rate,							*
	 * We can pick the current frame from the controller using the Frame() method	*/
		Frame frame = controller.Frame();

		/* Let's check how many hands we see */
		if(frame.Hands.Count > 0){
			Hand firstHand = frame.Hands[0];
			/* Convert the tip position of our hand from the Leap Motion Coordinate System *
		 * to the unity coordinate system 												 */
			Vector palmPos = firstHand.PalmPosition;
			/* Now get the world position by translating unityPos from local to world space  */
			Vector3 unityPos = palmPos.ToUnityScaled(false);

			unityPos.x = unityPos.x * 30;
			unityPos.y = unityPos.y * 30 + 1;
			unityPos.z = unityPos.z * 30 - 3;
			/* Finally set the object position */
			somethingToMove.transform.position = unityPos;


		}
	}
}