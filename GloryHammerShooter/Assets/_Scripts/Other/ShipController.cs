using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	private float speed = 3f;
	public Transform laserSpawn;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	float fireInterval = 0.15f;
	float fireTime;
	public AudioSource laserFire;
	public Text healthText;
	public float health = 3f;
	public AudioSource death;
	private bool upgrade = false;
	private bool invincible = false;
	public AudioSource powerUp;
	public Text powerUpAlert;
	public GameObject playerExplosion;
	public GameObject playerDamage;
	private GameController gameController;
	public AudioSource DamageSound;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		rb = gameObject.GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		healthText.text = "Shields: " + health;

		if (Input.GetButton ("Right")) 
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}

		if( Input.GetButton("Left"))
		{
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetButton ("Up")) 
		{
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}

		if( Input.GetButton("Down"))
		{
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
			
		//Full Auto input from user Raziaar on Unity Forum

		if(Input.GetKey(KeyCode.Space) & fireTime <= 0 & upgrade == true)
		{
			SuperFire();
			fireTime = fireInterval;

		}
		else if(Input.GetKey(KeyCode.Space) & fireTime <= 0 & upgrade == false)
		{
			Fire();
			fireTime = fireInterval;

		}

		if (fireTime > 0)
		{
			fireTime -= Time.deltaTime;
		}
			
	}

	void Fire(){
		laserFire.Play ();
		GameObject laser = (GameObject) Instantiate(LaserPrefab, laserSpawn.position, laserSpawn.rotation);
		Vector2 laserMotion = new Vector2 (30f, 0f);
		laser.GetComponent<Rigidbody2D>().AddForce(laserMotion * 50);
		Destroy (laser, 2f);
	}
		
	void SuperFire(){
		laserFire.Play ();

		Vector3 laser2Offset = new Vector3(0f, 0.1f, 0f);
		Vector3 laser3Offset = new Vector3(0f, -0.1f, 0f);

		GameObject laser = (GameObject) Instantiate(LaserPrefab, laserSpawn.position, laserSpawn.rotation);
		GameObject laser2 = (GameObject) Instantiate(LaserPrefab, laserSpawn.position + laser2Offset, laserSpawn.rotation);
		GameObject laser3 = (GameObject) Instantiate(LaserPrefab, laserSpawn.position + laser3Offset, laserSpawn.rotation);

		Vector2 laserMotion = new Vector2 (30f, 0f);
		laser.GetComponent<Rigidbody2D>().AddForce(laserMotion * 50);
		Destroy (laser, 2f);


		Vector2 laserMotion2 = new Vector2 (30f, 5f);
		laser2.GetComponent<Rigidbody2D>().AddForce(laserMotion * 50);
		Destroy (laser2, 2f);


		Vector2 laserMotion3 = new Vector2 (30f, -5f);
		laser3.GetComponent<Rigidbody2D>().AddForce(laserMotion * 50);
		Destroy (laser3, 2f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("enemy") && health <= 1) {
			StartCoroutine (Death ());
			Destroy (other.gameObject);

		} else if (other.tag.Equals ("enemy")) {
			Destroy (other.gameObject);
			Instantiate (playerDamage, transform.localPosition, transform.rotation);
			DamageSound.Play ();
			StartCoroutine(Damage ());
		}
		else if (other.tag.Equals ("magic")) {
			Instantiate (playerDamage, transform.localPosition, transform.rotation);
			DamageSound.Play ();
			StartCoroutine(Damage());
		} else if (other.tag.Equals ("blackhole")) {
			StartCoroutine (Death ());
			death.Play ();
		} else if (other.tag.Equals ("destroyer")) {
			StartCoroutine (Death ());
			death.Play ();
		} else if (other.tag.Equals ("boss")) {
			Destroy (gameObject);
			death.Play ();
		} else if (other.tag.Equals ("healthPickUp") && health < 5){
			Destroy (other.gameObject);
			powerUp.Play();
			health++;
		} else if (other.tag.Equals("powerUp")){
			Destroy (other.gameObject);
			upgrade = true;
			powerUp.Play ();
			StartCoroutine (PowerUpText ());
		}
	}
	IEnumerator Death(){
		health--;
		death.Play ();
		gameController.PlayerDead ();
		Instantiate (playerExplosion, transform.position, transform.rotation);
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
	}
	IEnumerator Damage(){
		if (invincible == false) {
				health--;
				invincible = true;
				yield return new WaitForSeconds (1f);
				invincible = false;
		}
	}

	IEnumerator PowerUpText(){
		powerUpAlert.enabled = true;
		yield return new WaitForSeconds (1f);
		powerUpAlert.enabled = false;
	}
}
