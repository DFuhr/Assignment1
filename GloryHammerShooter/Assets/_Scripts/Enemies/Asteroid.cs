using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	private Rigidbody2D rb;
	private float speed = 2f;
	public GameObject playerLaserExplosion;

	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();
		float moveH = Random.Range(-2f, 2f);
		float moveV = -2f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().Rotate(
			new Vector3(0f, 0f, 2f));
		Destroy (gameObject, 10f);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("bullet")) {
			Instantiate (playerLaserExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
		}
	}
}
