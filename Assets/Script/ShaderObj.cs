using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderObj : MonoBehaviour {

	// Use this for initialization
	private GameObject objectToFollow;

	void Start () {
		objectToFollow = GameObject.FindGameObjectWithTag ("Bottle");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (objectToFollow.transform.position.x, 0, objectToFollow.transform.position.z);
	}
}
