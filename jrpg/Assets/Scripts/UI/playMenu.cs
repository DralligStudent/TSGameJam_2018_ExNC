using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//you need this when using SceneManager

public class playMenu : MonoBehaviour {

    public GameObject newGame;//the buttons
    public GameObject loadGame;
    public GameObject back;

	public GameObject easy;//the difficulty buttons
	public GameObject normal;
	public GameObject hard;
	public GameObject back2;

	public GameObject difficultyOptions;//the menus
	public GameObject gameOptions;


	private int currentSelection;//the currently selected button
	private int numButtons;//total number of buttons

    // Use this for initialization
    void Start () {

		currentSelection = 1;
		numButtons = 3;
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.W))
			currentSelection--;

		if(Input.GetKeyDown (KeyCode.S))
			currentSelection++;

		if (currentSelection > numButtons)//loops the selection
			currentSelection = 1;
		else if (currentSelection < 1)
			currentSelection = numButtons;
	
		if (gameOptions.activeSelf) //checks if it should be displaying the play options
		{
			numButtons = 3;//there are 3 buttons on the play menu

			if (currentSelection == 1)
			{
				newGame.SetActive (true);
				loadGame.SetActive (false);
				back.SetActive (false);
			} 
			else if (currentSelection == 2)
			{
				newGame.SetActive (false);
				loadGame.SetActive (true);
				back.SetActive (false);
			}
			else if (currentSelection == 3)
			{
				newGame.SetActive (false);
				loadGame.SetActive (false);
				back.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.E)) 
			{
				if (currentSelection == 1) //load the difficulty select menu and hide the play menu
				{
					gameOptions.SetActive (false);
					difficultyOptions.SetActive (true);
				} 
				else if (currentSelection == 2) 
				{
					//loads the save file
				} 
				else if (currentSelection == 3) 
				{
					SceneManager.LoadScene (0);//Loads the menu
				}
			}

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0);//Goes back to the main menu
            }

        }
		else if(difficultyOptions.activeSelf) //difficulty options
		{
			numButtons = 4;

			if (currentSelection == 1)
			{
				easy.SetActive (true);
				normal.SetActive (false);
				hard.SetActive (false);
				back2.SetActive (false);
			} 
			else if (currentSelection == 2)
			{
				easy.SetActive (false);
				normal.SetActive (true);
				hard.SetActive (false);
				back2.SetActive (false);
			}
			else if (currentSelection == 3)
			{
				easy.SetActive (false);
				normal.SetActive (false);
				hard.SetActive (true);
				back2.SetActive (false);
			}
			else if (currentSelection == 4)
			{
				easy.SetActive (false);
				normal.SetActive (false);
				hard.SetActive (false);
				back2.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.E)) 
			{
				if (currentSelection == 1) 
				{
					PlayerPrefs.SetString ("difficulty", "easy");//sets the string 'difficulty' to be equal to easy. This can be called from any scene 
					SceneManager.LoadScene(2);//loads the next level
				}
				else if (currentSelection == 2) 
				{
					PlayerPrefs.SetString ("difficulty", "normal");
					SceneManager.LoadScene(2);
				} 
				else if (currentSelection == 3) 
				{
					PlayerPrefs.SetString ("difficulty", "hard");
					SceneManager.LoadScene(2);
				}
				else if (currentSelection == 4)//switches between menus 
				{
					gameOptions.SetActive (true);
					difficultyOptions.SetActive (false);
				}
			}

            if (Input.GetKeyDown(KeyCode.Q))//goes back to the previous menu
            {
                gameOptions.SetActive(true);
                difficultyOptions.SetActive(false);
            }
        }
	}
}
