using UnityEngine;
using System.Collections;
public class GyroRotate : MonoBehaviour {

	private Gyroscope gyro;
	private GameObject player;
	private Vector3 lastRotation, currentRotation;
	private Quaternion initPositionPlayer;

	private bool start = false;

	void Start () 
	{


		player = GameObject.FindGameObjectWithTag ("Player");
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;

			initPositionPlayer = player.transform.rotation;
			currentRotation = new Vector3 (0,0,0);
			lastRotation = new Vector3 (0,0,0);
		}
		else
		{
			Debug.Log("Phone doesen't support");
		}
	}

	void Update () 
	{
		lastRotation = currentRotation;
		currentRotation = gyro.rotationRateUnbiased;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		//player.transform.Rotate (-Input.gyro.rotationRateUnbiased.x * 5, -Input.gyro.rotationRateUnbiased.y * 5, 0);

		float xAbs = Mathf.Abs (lastRotation.x - currentRotation.x);
		float yAbs = Mathf.Abs (lastRotation.y - currentRotation.y);
		float zAbs = Mathf.Abs (lastRotation.z - currentRotation.z);

//		Debug.Log (xAbs + " - " + yAbs + " - " + zAbs);


		if(Input.GetKeyDown("space")){
			start = true;
		}

		if (start) {
			//player.transform.Rotate (-Input.gyro.rotationRateUnbiased.x * 3, -Input.gyro.rotationRateUnbiased.y * 3, 0);
			if(xAbs > 0.05 || yAbs > 0.05 || zAbs > 10.05){
				player.transform.Rotate (-Input.gyro.rotationRateUnbiased.x * 3, -Input.gyro.rotationRateUnbiased.y * 3, 0);
			}
		}
		/*

		*/


		//player.transform.rotation = initPositionPlayer;
	}
}