using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float moveH = -10f;
		float moveV = 0f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);

		Destroy (gameObject, 5f);
		
	}
}
