using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	// Use this for initialization
	private float entranceSpeed = 0.6f;
	public Transform laserSpawn;
	public Transform normalPos;
	public GameObject LaserPrefab;
	private Rigidbody2D rb;
	private float health = 400f;
	private float healthCounter;
	public Text healthText;
	private bool entrance = true;
	private bool firstthreshold = false;
	private bool secondthreshold = false;
	private bool thirdthreshold = false;
	private bool fourththreshold = false;
	private bool fifththreshold = false;
	private bool invincibility = true;
	public Transform playerPos;
	private float timeElapsed;
	public GameObject swordPrefab;
	public GameObject upSwordPrefab;
	public GameObject spearPrefab;
	public Transform swordSpawn;
	public Transform upSwordSpawn;
	public Transform spearSpawn;
	public Transform blackholeSpawn;

	void Start () {
		healthCounter = health;
		rb = gameObject.GetComponent <Rigidbody2D>();
			InvokeRepeating ("Barrage", 0f, 0.03f);
	}

	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		healthText.text = "Zargothrax: " + healthCounter;

		if (entrance == true) {
			float step = entranceSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, normalPos.position, step);
			StartCoroutine(EntranceStop());
		} 
		if (firstthreshold == false && secondthreshold == false && thirdthreshold == false && fourththreshold == false && fifththreshold == false) {
			if (timeElapsed % 2 < 0.03 && entrance == false) {
				SpawnSword ();
			}

			if (timeElapsed % 2 < 0.03 && entrance == false) {
				SpawnUpSword ();
			}

			if (timeElapsed % 2 < 0.03 && entrance == false) {
				SpawnSpear ();
			}

			if (health <= 300) {
				firstthreshold = true;
			}

			if (firstthreshold == true) {
				StartCoroutine (StartBarrage ());
			}

		}

	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("bullet") && health == 0) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else if (other.tag.Equals ("bullet")) {
			Destroy (other.gameObject);
			health--;
		} else if (other.tag.Equals ("bullet") && invincibility == true) {
			Destroy (other.gameObject);
		}
	}

	IEnumerator EntranceStop(){
		yield return new WaitForSeconds(10f);
		entrance = false;
		invincibility = false;
	}
		
	public void SpawnSword(){
		Vector3 spawnOffset = new Vector3(Random.Range(-10f, 10f), 0f, 0f);
		var sword = (GameObject)Instantiate(swordPrefab,
		swordSpawn.position + spawnOffset, swordSpawn.rotation);
	}

	public void SpawnUpSword(){
		Vector3 spawnOffset = new Vector3(Random.Range(-10f, 10f), 0f, 0f);
		var upSword = (GameObject)Instantiate(upSwordPrefab,
		upSwordSpawn.position + spawnOffset, upSwordSpawn.rotation);
	}

	public void SpawnSpear(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		var spear = (GameObject)Instantiate(spearPrefab,
			spearSpawn.position + spawnOffset, spearSpawn.rotation);
	}

	IEnumerator StartBarrage(){
		InvokeRepeating ("Barrage", 0f, 0.2f);
		yield return new WaitForSeconds (10f);
		CancelInvoke();
		firstthreshold = false;
		fourththreshold = false;
	}

	public void Barrage(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		GameObject laser = (GameObject) Instantiate(LaserPrefab, spearSpawn.position + spawnOffset, spearSpawn.rotation);
		Vector2 laserMotion = new Vector2 (-30f, 0f);
		laser.GetComponent<Rigidbody2D>().AddForce(laserMotion * 20);
		Destroy (laser, 5f);
	}

	public void SuperBlackHole(){

	}
	void ThresholdAttack(){
	}
		
	void Death(){
	}
}
