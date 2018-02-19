using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ace : MonoBehaviour {

	private Vector3 pos1;
	public float speed = 1.0f;
	public float amplitude = 2.0f;
	float t = 0f;
	public Transform laserSpawn;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	private float health = 6f;
	public AudioSource enemyFire;
	public AudioSource enemyDeathS;

	// Use this for initialization
	void Start () {
		pos1.x = 12f;
		pos1.y = Random.Range (-5f, 5f);
		rb = gameObject.GetComponent <Rigidbody2D>();
		InvokeRepeating("Fire", 1f, 1f);
		transform.position = pos1;

		float moveH = -3f;
		float moveV = 0f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);
	}

	// Code for zig zag movement pattern inspired by Stack Exchange user Luke Taylor

	// Update is called once per frame
	void Update () {
		pos1.y = amplitude * Mathf.Cos(t);
		pos1.x += speed * Time.deltaTime;
		t += Time.deltaTime;
		transform.position = -pos1;
	}

	void Fire(){
		GameObject laser = (GameObject) Instantiate(LaserPrefab, laserSpawn.position, laserSpawn.rotation);

		Vector2 laserMotion = new Vector2 (-15f, 0f);
		laser.GetComponent<Rigidbody2D>().AddForce(laserMotion * 15);
		Destroy (laser, 7f);
		enemyFire.Play ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("Player")) {
			Destroy (gameObject);
		}
		if (other.tag.Equals("bullet") && health == 0){
			Destroy(other.gameObject);
			Destroy(gameObject);
		}else if (other.tag.Equals("bullet")){
			Destroy(other.gameObject);
			health--;
		}else if(other.tag.Equals ("Boundary")) {
			Destroy (gameObject);
		}
	}
}
