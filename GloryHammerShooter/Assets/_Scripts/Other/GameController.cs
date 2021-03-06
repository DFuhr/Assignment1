
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Transform asteroidSpawn;
	public Transform upAsteroidSpawn;
	public GameObject enemyCraftPrefab;
	public GameObject asteroidPrefab;
	public GameObject upAsteroidPrefab;
	public GameObject blackHolePrefab;
	public GameObject destroyerPrefab;
	public GameObject acePrefab;
	private float speed;
	private float timeElapsed;
	public int score = 0;
	private int scoreCounter;
	public Text scoreText;
	public Image DeathScreen;
	public Text DeathText;

	public bool gameOver;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		gameOver = false;
	}

	void Start () {
		UpdateScore ();

	}

	// Update is called once per frame
	void Update () {
		
		scoreText.text = "Score: " + score;

		timeElapsed += Time.deltaTime;
		if (timeElapsed % 3 < 0.04)
			{
				SpawnAlien ();
			}

		if (timeElapsed % 3 < 0.01)
			{
				SpawnAsteroid ();
			}

		if (timeElapsed % 3 < 0.01)
			{
				SpawnUpAsteroid ();
			}

		if (timeElapsed % 2 < 0.002)
			{	
				SpawnBlackHole ();
			}
		if (timeElapsed % 2 < 0.002)
			{
				SpawnDestroyer ();
			}
		if (timeElapsed % 3 < 0.02)
			{
				//SpawnAce ();
			}

			
		if (gameOver && Input.GetKeyDown (KeyCode.R)) {				
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		} else if (gameOver && Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Menu");
		}
	}
	public void SpawnAlien(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		var enemy = (GameObject)Instantiate(enemyCraftPrefab,
			transform.position + spawnOffset, transform.rotation);
		enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
		Destroy (enemy, 20);
	}

	public void SpawnAsteroid(){
		Vector3 spawnOffset = new Vector3(Random.Range(-10f, 10f), 0f, 0f);
		var asteroid = (GameObject)Instantiate(asteroidPrefab,
			asteroidSpawn.position + spawnOffset, asteroidSpawn.rotation);
		asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,speed-0.5f));
	}

	public void SpawnUpAsteroid(){
		Vector3 spawnOffset = new Vector3(Random.Range(-10f, 10f), 0f, 0f);
		var upasteroid = (GameObject)Instantiate(upAsteroidPrefab,
			upAsteroidSpawn.position + spawnOffset, upAsteroidSpawn.rotation);
		upasteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,speed-0.5f));
	}

	public void SpawnBlackHole(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		var blackhole = (GameObject)Instantiate(blackHolePrefab,
			transform.position + spawnOffset, transform.rotation);
		blackhole.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
	}

	public void SpawnDestroyer(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		var destroyer = (GameObject)Instantiate(destroyerPrefab,
			transform.position + spawnOffset, transform.rotation);
		destroyer.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed / 1.5f, 0f));
	}

	public void SpawnAce(){
		Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
		var ace = (GameObject)Instantiate(acePrefab,
			transform.position + spawnOffset, transform.rotation);
		//ace.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed / 1.5f, 0f));
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void ScoreIncrementAlien(){
		score += 100;
		UpdateScore ();
	}

	public void ScoreIncrementDestroyer(){
		score += 500;
		UpdateScore ();
	}

	public void PlayerDead()
	{
		DeathScreen.enabled = true;
		DeathText.enabled = true;
		gameOver = true;
		Debug.Log ("PLAYER DEAD");
	}

}
