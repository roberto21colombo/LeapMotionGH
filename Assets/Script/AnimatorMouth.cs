using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMouth : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			Debug.Log ("Premuto M");
			anim.Play ("Mouth");
		}
	}
}
