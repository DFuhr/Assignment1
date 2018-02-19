using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().Rotate(
			new Vector3(0f, 0f, -1f));

		Destroy (gameObject, 100f);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
		} else if (other.tag.Equals ("Player")) {
			Destroy (other.gameObject);
		}
	}
}

