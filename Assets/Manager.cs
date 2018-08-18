using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Use this for initialization
	private int currentPointer = 0;
	
	public Pivot seconds;
	public Pivot minutes;
	public Pivot hours;

	private int resultSeconds;
	private int resultMinutes;
	private int resultHours;

	private Pivot pointer;
	void Start () {
		getResult();
	}

	void randomResult(){
		resultSeconds = Random.Range(0,59);
		resultMinutes = Random.Range(0,59);
		resultHours = Random.Range(0,11);

		print(resultHours + ":" + resultMinutes + ":" + resultSeconds);
	}

	void getResult(){
		resultSeconds = 3
		resultMinutes = 5
		resultHours = 2
	}

	void checkResult(){
		print(hours.getIndex() + ":" + minutes.getIndex() + ":" + seconds.getIndex());
		if( resultSeconds == seconds.getIndex() && resultMinutes == minutes.getIndex() && resultHours == hours.getIndex()){
			print("ACERTEI");
		}
	}

	void setCurrent(int index){
		switch (index){
			case 0:
			
			pointer = hours;
			break;
			case 1:
			pointer = minutes;
			break;
			case 2:
			pointer = seconds;
			break;
			default:
			break;
		};
		// currentPointer;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			
			currentPointer = (currentPointer-1)%3;
			if(currentPointer < 0){
				currentPointer = 2;
			}
			
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			currentPointer = (currentPointer+1)%3;
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			// print(currentPointer);
			setCurrent(currentPointer);
			pointer.setPosition(true);
			checkResult();
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			// print(currentPointer);
			setCurrent(currentPointer);
			pointer.setPosition(false);
			checkResult();
			// transform.Rotate(new Vector3(0f, -secondsToDegrees ,0f));
		}
	}
}
