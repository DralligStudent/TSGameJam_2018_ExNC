using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startBattle : MonoBehaviour {

	public Slider slider;//the slider game object
	private float startTime;//the time the player started holding load level
	private float loadTime;//the ammount of time the player has been loading for

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.S)) 
		{
			startTime = Time.time;//the time the player started holding the S key
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			loadTime = Time.time - startTime;//the amount of time the player has been holding the S key
			slider.value = ((loadTime) / 2);//takes 2 seconds to fill the slider
		}
		if (Input.GetKeyUp (KeyCode.S))//resets the slider if the player releases the S key
		{
			slider.value = 0;
		}

		if (slider.value == 1)//when the bar is full
		{
			SceneManager.LoadScene("battleScene");//load the battle scene
		}
	}
}
