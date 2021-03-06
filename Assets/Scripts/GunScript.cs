﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public float damage = 10f;
	public float range = 10f;
	public float impactForce = 30f;
	public float fireRate = 0.0001f;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	public AudioSource shootAudio;

	private float nextTimeToFire = 0f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time >= nextTimeToFire) {
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot ();
		}
	}

	void Shoot () {
	
		shootAudio.Play ();
		muzzleFlash.Play ();

		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			
			TargetScript target = hit.transform.GetComponent<TargetScript> ();
			if (target != null) {
				target.TakeDamage (damage);

			}

			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce(-hit.normal * impactForce );		
			
			}

			GameObject impactGo = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGo, 2f);
		}


	}

}
