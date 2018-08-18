using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	private int currentPointer = 0;
	
	public Pivot seconds;
	public Pivot minutes;
	public Pivot hours;

	public float minutesHoldingInterval;
	public float hourHoldingInterval;

	private float currentHoldInterval;

	public float firstHoldTimeout;
	private float holdTimer;
	private bool holdActive = false;

	private int resultSeconds;
	private int resultMinutes;
	private int resultHours;

	private Pivot pointer;

	void Start () {
		restartGame();
	}

	void restartGame(){
		generateResult();
		randomHour();
	}

	void randomHour(){
		int randomSeconds = (int) Random.Range(0,59);
		int randomMinutes = (int) Random.Range(0,59);
		int randomHours = (int) Random.Range(0,11);

		seconds.setIndex(randomSeconds);
		minutes.setIndex(randomMinutes);
		hours.setIndex(randomHours);
	}

	void generateResult(){
		resultSeconds = 3;
		resultMinutes = 5;
		resultHours = 2;
		print(resultHours + ":" + resultMinutes + ":" + resultSeconds);
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
	}
	
	void setCurrentPointer(int offset){
		currentPointer = (currentPointer - offset)%3;
		if(currentPointer < 0){
			currentPointer = 2;
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)){		
			setCurrentPointer(-1);			
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			setCurrentPointer(1);
		}

		checkClickAndContinuousMovement(KeyCode.DownArrow);
		checkClickAndContinuousMovement(KeyCode.UpArrow);
	}

	void checkClickAndContinuousMovement(KeyCode keyCode){
		bool isUp = keyCode == KeyCode.UpArrow;
		
		// CHECK UP ARROW
		if(Input.GetKeyDown(keyCode)){
			holdTimer = 0;
			holdActive = false;
			setCurrent(currentPointer);
			pointer.setDirection(isUp);
			if(pointer.isHour){
				currentHoldInterval = hourHoldingInterval;
			}else{
				currentHoldInterval = minutesHoldingInterval;				
			}
		}
		
		if(Input.GetKey(keyCode)){
			holdTimer += Time.deltaTime;
			if(!holdActive && holdTimer > firstHoldTimeout){				
				holdActive = true;				
			}
			if(holdActive && holdTimer > currentHoldInterval){
				holdTimer = 0;
				setCurrent(currentPointer);
				pointer.setDirection(isUp);
			}
		}

		if(Input.GetKeyUp(keyCode)){
			checkResult();
		}
	}
}
