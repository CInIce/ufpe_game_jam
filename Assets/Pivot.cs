using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float speed;
	private const float hoursToDegrees = 360f/12f,
	minutesToDegrees = 360f/60f,
	secondsToDegrees= 6f;
	void Start () {
		
	}
	

	void setPosition(bool isUp){
		if(isUp){
			transform.Rotate(new Vector3(0f, secondsToDegrees ,0f));
		}else{
			transform.Rotate(new Vector3(0f, -secondsToDegrees ,0f));
		}
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
