﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float speed;
	private const float hoursToDegrees = 360f/12f,
	minutesToDegrees = 360f/60f,
	secondsToDegrees= 6f;
	private int offset = -90;
	void Start () {
		transform.Rotate(new Vector3(0f, offset ,0f));
	}
	

	void rotate(){

	}
	// Update is called once per frame
	void Update () {
		print(Mathf.Floor(((transform.eulerAngles.y - offset)/secondsToDegrees) % 60));
		float step = speed * Time.deltaTime;
		// var x = Input.GetAxis("Horizontal");
		// var y = Input.GetAxis("Vertical");
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			transform.Rotate(new Vector3(0f, secondsToDegrees ,0f));
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			transform.Rotate(new Vector3(0f, -secondsToDegrees ,0f));
		}
		// transform.Rotate(new Vector3(0f, step ,0f));
		// rotate();
	}
}
