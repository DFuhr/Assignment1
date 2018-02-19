using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapWing : MonoBehaviour {

	public Transform WingPivot;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Transform>().RotateAround(WingPivot.position, Vector3.left, 3f);
	}
}
