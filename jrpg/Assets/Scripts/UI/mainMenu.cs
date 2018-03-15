using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//you need this when using SceneManager

public class mainMenu : MonoBehaviour {

    public GameObject playSelect;//the buttons
    public GameObject creditsSelect;
    public GameObject quitSelect;

    public Renderer playRend;//the button renderers
    public Renderer creditsRend;
    public Renderer quitRend;

	private int currentSelection;//the currently selected button
	private int numButtons;//total number of buttons

    // Use this for initialization
    void Start () {
		playRend = playSelect.GetComponent<Renderer>();//gets the button renderers
		creditsRend = creditsSelect.GetComponent<Renderer>();
		quitRend = quitSelect.GetComponent<Renderer>();

		currentSelection = 1;
		numButtons = 3;
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.W))//scrolls up
			currentSelection--;

		if(Input.GetKeyDown (KeyCode.S))//scrolls down
			currentSelection++;

		if (currentSelection > numButtons)//loops selection from top to bottom
			currentSelection = 1;
		else if (currentSelection < 1)
			currentSelection = numButtons;
	
		if (currentSelection == 1)//renders the correct button
		{
			playRend.enabled = true;
			creditsRend.enabled = false;
			quitRend.enabled = false;
		}
		else if(currentSelection == 2)
		{
			creditsRend.enabled = true;
			playRend.enabled = false;
			quitRend.enabled = false;
		}
		else if(currentSelection == 3)
		{
			quitRend.enabled = true;
			playRend.enabled = false;
			creditsRend.enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.E)) //checks what the player wants to select
		{
			if (currentSelection == 1)
			{
				SceneManager.LoadScene("overworldScene");//loads the overWorld scene
			}
			else if(currentSelection == 2)
			{
				SceneManager.LoadScene("credits");//loads the credits scene
			}
			else if(currentSelection == 3)
			{
				Application.Quit();//quits the game
			}
		}
	}
}
