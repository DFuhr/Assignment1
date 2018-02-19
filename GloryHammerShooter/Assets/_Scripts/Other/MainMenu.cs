using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

	public Text ComingSoonText;

	public void LevelOne(){
		SceneManager.LoadScene ("Level01");
	}

	public void LevelTwo(){
		SceneManager.LoadScene ("Level02");
	}

	public void LevelThree(){
		SceneManager.LoadScene ("Level03");
	}

	public void LevelFour(){
		ComingSoonText.enabled = true;
	}
}
