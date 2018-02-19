using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();

		float moveH = -10f;
		float moveV = 0f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);
	}

	void Update(){
		gameObject.GetComponent<Transform>().Rotate(
			new Vector3(-3f, -3f, -3f));
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("player")) {
			Destroy (gameObject);
		} else if (other.tag.Equals ("boundary")) {
			Destroy (gameObject);
		}
	}
}
