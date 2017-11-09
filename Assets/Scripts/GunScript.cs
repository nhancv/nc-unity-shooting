using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public float damage = 10f;
	public float range = 10f;


	public Camera fpsCam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot () {
	
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.transform.name);
			TargetScript target = hit.transform.GetComponent<TargetScript> ();
			if (target != null) {
				target.TakeDamage (damage);

			}
		}


	}

}
