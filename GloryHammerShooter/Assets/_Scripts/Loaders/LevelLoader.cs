/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	Button btnLevel1;
	Button btnLevel2;
	Button btnLevel3;
	Button btnLevel4;

 void Start(){
	 	btnLevel1 = GameObject.Find ("Level 1 Button");
		btnLevel2 = GameObject.Find ("Level 2 Button");
		btnLevel3 = GameObject.Find ("Level 3 Button");
		btnLevel4 = GameObject.Find ("Level 4 Button");
 }

	void Update(){
		Button btn1 = btnLevel1.GetComponent<Button> ();
		btnLevel1.onClick.AddListener (SceneManager.LoadScene ("Level01"));

		Button btn2 = btnLevel2.GetComponent<Button> ();
		btnLevel2.onClick.AddListener (SceneManager.LoadScene ("Level02"));

		Button btn3 = btnLevel3.GetComponent<Button> ();
		btnLevel3.onClick.AddListener (SceneManager.LoadScene ("Level03"));

		Button btn4 = btnLevel4.GetComponent<Button> ();
		btnLevel4.onClick.AddListener (SceneManager.LoadScene ("Level04"));
	}

}
*/