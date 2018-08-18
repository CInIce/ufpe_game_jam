using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTime : MonoBehaviour {

	public Manager gameManager;
	public float totalTime;
	private float currentTime;
	
	void Start () {
		currentTime = 0;	
	}
	
	void Update () {
		currentTime += Time.deltaTime;
		if(currentTime >= totalTime){
			currentTime = 0;
			gameManager.restartGame();
		}
	}
}
