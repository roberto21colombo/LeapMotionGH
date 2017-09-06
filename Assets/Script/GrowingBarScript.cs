using UnityEngine;
using System.Collections;

public class GrowingBarScript : MonoBehaviour {


	void Start () 
	{
		
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.localScale += new Vector3(0, 1F, 0);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.localScale -= new Vector3(0, 1F, 0);
		}
	}
}