using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public float speed;
	public Transform laserSpawn;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	private float health = 4f;
	public AudioSource enemyFire;
	public AudioSource enemyDeathS;
	private GameController gameController;
	public GameObject playerLaserExplosion;
	public GameObject FighterExplosion;
	public GameObject HealthDrop;

	void Start () {

		//Score tracker found from Unity Tutorials
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		rb = gameObject.GetComponent <Rigidbody2D>();
		InvokeRepeating("Fire", 1f, 2f);

		float moveH = -10f;
		float moveV = 0f;

		Vector2 motion = new Vector2 (moveH, moveV);

		rb.AddForce (motion * speed);
	}
	
	// Update is called once per frame
	void Update () {

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
			StartCoroutine(Death());
		}
		if (other.tag.Equals("bullet") && health == 0){
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
		enemyDeathS.Play ();
		Instantiate (FighterExplosion, transform.position, transform.rotation);
		int drop = Random.Range (1, 101);
		if (drop <= 5) {
			Instantiate (HealthDrop, transform.position, transform.rotation);
		} 
		transform.Translate (Vector3.right * 9999f);
		gameController.ScoreIncrementAlien();
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
