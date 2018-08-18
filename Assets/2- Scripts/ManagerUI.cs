using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{

    // Use this for initialization
    public Button selectHour;
    public Button selectMinutes;
    public Button selectSeconds;
    private GameObject[] buttons;
	public Manager manager;
    private Button currentButton;
	
    void Start()
    {
        // buttons = new GameObject[3];
        // for(int i =0; i< 3; i++){
        // 	// buttons
        // }
    }

    // Update is called once per frame

	void paint(Button button, Color color)
	{ 
		ColorBlock cb = button.colors;
		cb.normalColor = color;
		button.colors = cb;

	}
    void activate(string name)
    {
		// Color green =  new Color(0, 1, 0, 1);
		// Color white =  new Color(0, 0, 0, 1);

        if (name.Equals("Hour"))
        {
			paint(selectHour,Color.green);
			paint(selectMinutes,Color.white);
			paint(selectSeconds,Color.white);
        }

        if (name.Equals("Minutes"))
        {
			paint(selectHour,Color.white);
			paint(selectMinutes,Color.green);
			paint(selectSeconds,Color.white);
        }

        if (name.Equals("Seconds"))
        {
			paint(selectHour,Color.white);
			paint(selectMinutes,Color.white);
			paint(selectSeconds,Color.green);
        }
    }

    void selectPointer(int index)
    {
        if (index == 0)
        {
            activate("Hour");
            // pointer = GameObject.Find("selectHour");
        }

        if (index == 1)
        {
			activate("Minutes");
            // pointer = GameObject.Find("selectHour");
        }

        if (index == 2)
        {
            // print("Entrei");
			activate("Seconds");
        }
    }
    void Update()
    {
		selectPointer(manager.currentPointer);
		// if(manager.currentPointer){

		// }
        // if (Input.GetButton("Fire1"))
        // {
        //     selectPointer(0);
        // }
    }

}
