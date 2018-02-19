﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelThreeVictory : MonoBehaviour {

	private GameController gameController;
	public Image VictoryImage;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
	}

	void Update () {
		if (gameController.score >= 20000) {
			StartCoroutine (Victory ());
		}
	}

	IEnumerator Victory(){
		VictoryImage.enabled = true;
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene ("Menu");
	}
}