using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent <Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 2f);
	}
}
