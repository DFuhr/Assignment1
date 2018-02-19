using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public float speed;
	public Transform laserSpawn;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	private float health = 19f;
	public AudioSource enemyFire;
	public AudioSource enemyDeathL;
	private GameController gameController;
	public GameObject playerLaserExplosion;
	public GameObject FighterExplosion;
	public GameObject DestroyerExplosion;
	public GameObject HealthDrop;
	public GameObject PowerDrop;
	private bool dead = false;

	void Start () {

		//Score tracker found from Unity Tutorials
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		rb = gameObject.GetComponent <Rigidbody2D>();
		InvokeRepeating("Fire", 1f, 1.5f);

		float moveH = -5f;
		float moveV = 0f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);
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

		Vector2 laserMotion2 = new Vector2 (-20f, 0f);
		laser2.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);


		Vector2 laserMotion3 = new Vector2 (-20f, 0f);
		laser3.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);

		enemyFire.Play ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag.Equals ("bullet") && health == 0 && dead == false) {
			dead = true;
			Destroy (other.gameObject);
			gameController.ScoreIncrementDestroyer ();
			Instantiate (playerLaserExplosion, other.transform.position, other.transform.rotation);
			StartCoroutine (Death ());
			enemyDeathL.Play ();
			int drop = Random.Range (1, 101);
			if (drop <= 80) {
				Instantiate (HealthDrop, transform.position, transform.rotation);
			} else {
				Instantiate (PowerDrop, transform.position, transform.rotation);
			}

		} else if (other.tag.Equals("bullet") && health == 0){
			Destroy(other.gameObject);
			Instantiate (playerLaserExplosion, other.transform.position, other.transform.rotation);
			StartCoroutine(Death());

		}else if (other.tag.Equals("bullet")){
			Instantiate (playerLaserExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			health--;

		}else if(other.tag.Equals ("Boundary")) {
			Destroy (gameObject);
		}
	}

	IEnumerator Death (){
		Vector3 explodeOffset = new Vector3(0f, 1f, 0f);
		InvokeRepeating ("Explode", 0f, 4f);
		Instantiate (FighterExplosion, transform.position + explodeOffset, transform.rotation);
		rb.gravityScale = 0.1f;
		gameObject.GetComponent<Transform>().Rotate(new Vector3(0f, 0f, 2f));
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
	}

	void Explode(){
		Vector3 explodeOffset = new Vector3(0f, 1f, 0f);
		Instantiate (DestroyerExplosion, transform.position + explodeOffset, transform.rotation);
	}
}

