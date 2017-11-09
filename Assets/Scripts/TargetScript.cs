using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
	public float health = 50f;
	public GameObject destroyEffect; 

	public void TakeDamage (float amount) {
		health -= amount;
		if (health <= 0f) {
			Die ();
		}

	}

	void Die() {
		GameObject destroyEffectGo = Instantiate (destroyEffect, transform.position, Quaternion.LookRotation(transform.position));
		Destroy (destroyEffectGo, 2f);

		Destroy (gameObject);
	}

}
