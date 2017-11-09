using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
	public float health = 50f;
	public GameObject destroyEffect;
	public GameObject player;
	private Vector3 spawn;

	private Rigidbody rigidBody;
	public AudioSource destroyAudio;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody>();
		spawn = transform.position;
	}

	void Update () {

		if (transform.position.y <= 264.55f) {
			Die ();
		}
	}

	public void TakeDamage (float amount) {
		health -= amount;
		if (health <= 0f) {
			Die ();
		}

	}

	void Die() {
		GameObject destroyEffectGo = Instantiate (destroyEffect, transform.position, Quaternion.Euler(270, 0, 0));
		Destroy (destroyEffectGo, 2f);
		destroyAudio.Play ();

		health = 50f;
		rigidBody.velocity = new Vector3(0f,0f,0f); 
		rigidBody.angularVelocity = new Vector3(0f,0f,0f); 
		transform.position = spawn;
		transform.rotation = Quaternion.Euler(new Vector3(0f,180,0f));


	}

}
