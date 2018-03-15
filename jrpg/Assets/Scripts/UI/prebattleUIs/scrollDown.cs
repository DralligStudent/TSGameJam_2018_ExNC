using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollDown : MonoBehaviour {

    public Scrollbar scrollbar;//the scrollbar
    public float listLength;//the amount of objects in the list
    public float scrollAmount = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        listLength = 20 - 0.48f;//change this to get the amount of ships in the list (0.48 is the extra space because there is room for 48% of another button at the bottom)

        if (Input.GetKeyDown(KeyCode.S) && scrollbar.value > 0.04)//if you want to go down and are not already at the bottom
        {
            scrollbar.value = (scrollbar.value - (1 / listLength));//go down 1 value in the list
            Debug.Log(scrollbar.value);
        }
        if (Input.GetKeyDown(KeyCode.W) && scrollbar.value < 1)//if you want to go up and are not already at the top of the list
        {
            scrollbar.value = scrollbar.value + (1 / listLength);//go up 1 value in the list
        }

    }
}
