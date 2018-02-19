using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float runtime;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, runtime);
	}
}
