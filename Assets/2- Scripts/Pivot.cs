﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float speed;
	public bool isHour;
	private const float hoursToDegrees = 360f/12f,
	secondsToDegrees= 360f/60f;
	private int initalOffset = -90;
	void Start () {		
		// transform.Rotate(new Vector3(0f, initalOffset ,0f));
	}	

	public void setIndex(int index){
		float offset = index * secondsToDegrees;
		if(isHour){
			offset = index * hoursToDegrees;
		}
		transform.eulerAngles = new Vector3(0f, initalOffset + offset ,0f);
		// transform.Rotate(new Vector3(0f, offset ,0f));
	}

	public void setDirection(bool isUp){
		float offset = secondsToDegrees;
		if(isHour){
			offset = hoursToDegrees;
		}
		if(isUp){
			transform.Rotate(new Vector3(0f, offset ,0f));
		}else{
			transform.Rotate(new Vector3(0f, -offset ,0f));
		}
	}

	public int getIndex(){
		int index = (int) Mathf.Round(((transform.eulerAngles.y - initalOffset)/secondsToDegrees) % 60);
		if(isHour){
			index = index / 5;
		}
		return index;
	}

	void rotate(){

	}
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		// var x = Input.GetAxis("Horizontal");
		// var y = Input.GetAxis("Vertical");
	
		// transform.Rotate(new Vector3(0f, step ,0f));
		// rotate();
	}
}
