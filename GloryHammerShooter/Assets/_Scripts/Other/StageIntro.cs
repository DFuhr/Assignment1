using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageIntro : MonoBehaviour {
	public Text introText;
	public Image beginText;

	// Use this for initialization
	void Start () {
		StartCoroutine(IntroSequence());
	}

	IEnumerator IntroSequence(){
		introText.enabled = true;
		yield return new WaitForSeconds (2f);
		introText.enabled = false;
		yield return new WaitForSeconds (0.5f);
		beginText.enabled = true;
		yield return new WaitForSeconds (2f);
		beginText.enabled = false;
	}
}
