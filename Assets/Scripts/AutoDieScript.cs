using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDieScript : MonoBehaviour {


	private Vector3 spawn;

	// Use this for initialization
	void Start () {

		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= 264.55f) {
			transform.position = spawn;
		}
	}
}
