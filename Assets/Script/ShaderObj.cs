using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderObj : MonoBehaviour {

	// Use this for initialization
	public GameObject objectToFollow;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (objectToFollow.transform.position.x, 0, objectToFollow.transform.position.z);
	}
}
