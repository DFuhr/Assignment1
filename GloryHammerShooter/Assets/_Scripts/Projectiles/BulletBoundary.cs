using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoundary : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
		}
	}
}
