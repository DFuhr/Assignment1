using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else if(other.tag.Equals ("Boundary")) {
			Destroy (gameObject);
		}
	}
}
