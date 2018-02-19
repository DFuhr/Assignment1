using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leviathan : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public Transform laserSpawn;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	private float health = 199f;

	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();
		InvokeRepeating("Fire", 1f, 1f);
	}

	// Update is called once per frame
	void Update () {

	}
	void Fire(){
		Vector3 laser2Offset = new Vector3(0f, 0.75f, 0f);
		Vector3 laser3Offset = new Vector3(0f, -0.75f, 0f);

		GameObject laser = (GameObject) Instantiate(LaserPrefab, laserSpawn.position, laserSpawn.rotation);
		GameObject laser2 = (GameObject) Instantiate(LaserPrefab, laserSpawn.position + laser2Offset, laserSpawn.rotation);
		GameObject laser3 = (GameObject) Instantiate(LaserPrefab, laserSpawn.position + laser3Offset, laserSpawn.rotation);

		Vector2 laserMotion = new Vector2 (-20f, 0f);
		laser.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);
		Destroy (laser, 5f);


		Vector2 laserMotion2 = new Vector2 (-20f, 0f);
		laser2.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);
		Destroy (laser2, 5f);


		Vector2 laserMotion3 = new Vector2 (-20f, 0f);
		laser3.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);
		Destroy (laser3, 5f);
	}

	void OnTriggerEnter2D(Collider2D other){
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

	void ThresholdAttack(){
	}

	void RamAttack(){
	}

	void SpawnFighters(){
	}

	void SpanAces(){
	}

	void PowerUp(){
	}

	void Death(){
	}
}
