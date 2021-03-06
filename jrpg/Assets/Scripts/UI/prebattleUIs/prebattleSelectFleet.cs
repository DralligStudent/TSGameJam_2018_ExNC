﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prebattleSelectFleet : MonoBehaviour {

    private int currentSelection;//the currently selected button
    private int previousSelection;//the previously selected button
    private int numButtons;//total number of buttons

    public Color defaultColour = Color.white;
    public Color fleetColour = new Color(0f, 1f, 0f, 1f);
    public Color enemyColour = new Color(1f, 0f, 0f, 1f);
    public Color selectColour;
    public bool enemy;//enabled in editor if its attached to the enemy fleet

    public GameObject target1, target2, target3, target4, target5, target6, target7, target8;//all the ship game objects
    SpriteRenderer targetSprite1, targetSprite2, targetSprite3, targetSprite4, targetSprite5, targetSprite6, targetSprite7, targetSprite8;//all the ship sprite renderers
    Image targetImage1, targetImage2, targetImage3, targetImage4, targetImage5, targetImage6, targetImage7, targetImage8;


    public GameObject fleet, prebattleSetup;
	public GameObject currentlySelected, shipStats, fleetInventory;

    private PreBattleState preBattleState;
    public PlayerInventory playerInventory;

    public GameObject detectorObject;
    detector detectorScript;
   

    // Use this for initialization
    void Start ()
    {
        currentSelection = 1;
        numButtons = 8;

        if (enemy)
            selectColour = enemyColour;//enemy fleet have red colours if selected
        else
            selectColour = fleetColour;//friendly fleet have green coulours if selected

        targetSprite1 = target1.GetComponent<SpriteRenderer>();//gets every ships sprite renderer for the border
        targetSprite2 = target2.GetComponent<SpriteRenderer>();
        targetSprite3 = target3.GetComponent<SpriteRenderer>();
        targetSprite4 = target4.GetComponent<SpriteRenderer>();
        targetSprite5 = target5.GetComponent<SpriteRenderer>();
        targetSprite6 = target6.GetComponent<SpriteRenderer>();
        targetSprite7 = target7.GetComponent<SpriteRenderer>();
        targetSprite8 = target8.GetComponent<SpriteRenderer>();

        targetImage1 = target1.GetComponentInChildren<Image>();//gets every ships Image
        targetImage2 = target2.GetComponentInChildren<Image>();
        targetImage3 = target3.GetComponentInChildren<Image>();
        targetImage4 = target4.GetComponentInChildren<Image>();
        targetImage5 = target5.GetComponentInChildren<Image>();
        targetImage6 = target6.GetComponentInChildren<Image>();
        targetImage7 = target7.GetComponentInChildren<Image>();
        targetImage8 = target8.GetComponentInChildren<Image>();

        preBattleState = GameObject.Find("PreBattleState").GetComponent<PreBattleState>();
        playerInventory = GameObject.Find("P_Inven").GetComponent<PlayerInventory>();

        detectorScript = detectorObject.GetComponent<detector>();
    }
	
	// Update is called once per frame
	void Update () {
        previousSelection = currentSelection;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSelection != 1 && currentSelection != 5)//checks if the currently selected button is not at the top of a column
            {
                currentSelection--;//selects the button above
            }
            else//if they are at the top
            {
                currentSelection = currentSelection + 3;//loops back to the bottom
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentSelection != 4 && currentSelection != 8)
            {
                currentSelection++;
            }
            else
            {
                currentSelection = currentSelection - 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
            currentSelection = currentSelection + 4;//moves the selection to the left

        if (Input.GetKeyDown(KeyCode.D))
            currentSelection = currentSelection -4;//moves the selection to the right

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))//checks if you have changed your selection
        {
            switch (previousSelection)//sets the previously selected ship to be the default colour again
            {
                case 8:
                    targetSprite8.color = defaultColour;
                    break;
                case 7:
                    targetSprite7.color = defaultColour;
                    break;
                case 6:
                    targetSprite6.color = defaultColour;
                    break;
                case 5:
                    targetSprite5.color = defaultColour;
                    break;
                case 4:
                    targetSprite4.color = defaultColour;
                    break;
                case 3:
                    targetSprite3.color = defaultColour;
                    break;
                case 2:
                    targetSprite2.color = defaultColour;
                    break;
                case 1:
                    targetSprite1.color = defaultColour;
                    break;
                default:
                    print("error with previous target");
                    break;
            }
        }

        if (currentSelection > numButtons)//loops the selection
            currentSelection = currentSelection - 8;//if the selection went out of bounds with A or D this loops it correctly
        else if (currentSelection < 1)
            currentSelection = currentSelection + 8;


        switch (currentSelection)//sets the currently selected ship to be the selection colour
        {
            case 8:
                targetSprite8.color = selectColour;
                break;
            case 7:
                targetSprite7.color = selectColour;
                break;
            case 6:
                targetSprite6.color = selectColour;
                break;
            case 5:
                targetSprite5.color = selectColour;
                break;
            case 4:
                targetSprite4.color = selectColour;
                break;
            case 3:
                targetSprite3.color = selectColour;
                break;
            case 2:
                targetSprite2.color = selectColour;
                break;
            case 1:
                targetSprite1.color = selectColour;
                break;
            default:
                print("error with current target");
                break;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //needs to output to game manager what position you have selected
            switch (currentSelection)
            {
                case 8:
                    print("attack 8");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage8;
                    break;
                case 7:
                    print("attack 7");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage7;
                    break;
                case 6:
                    print("attack 6");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage6;
                    break;
                case 5:
                    print("attack 5");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage5;
                    break;
                case 4:
                    print("attack 4");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage4;
                    break;
                case 3:
                    print("attack 3");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage3;
                    break;
                case 2:
                    print("attack 2");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage2;
                    break;
                case 1:
                    print("attack 1");
                    preBattleState.setFormationIndex(currentSelection);
                    detectorScript.targetImage = targetImage1;
                    break;
                case 0:
                    print("attack 0");
                    preBattleState.setFormationIndex(currentSelection);
                    break;
                default:
                    print("error with attack target");
                    break;
            }
			fleet.SetActive (false); prebattleSetup.SetActive (false);//hides the 2 panels we dont want to show any more
			currentlySelected.SetActive (true); shipStats.SetActive (true); fleetInventory.SetActive (true);//enables the 3 that allow the player to select a ship
        }

		if (Input.GetKeyDown(KeyCode.Z))//Z will clear that position of whatever ship is currently in that slot
		{
			//needs to output to game manager what position to clear
			switch (currentSelection)
			{
			case 8:
				print("clear 8");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage8.sprite = null;
                break;
			case 7:
				print("clear 7");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage7.sprite = null;
				break;
			case 6:
				print("clear 6");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage6.sprite = null;
				break;
			case 5:
				print("clear 5");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage5.sprite = null;
				break;
			case 4:
				print("clear 4");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage4.sprite = null;
				break;
			case 3:
				print("clear 3");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage3.sprite = null;
				break;
			case 2:
				print("clear 2");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage2.sprite = null;
				break;
			case 1:
				print("clear 1");
                preBattleState.setFormationIndex(currentSelection);
                preBattleState.battleFormation[preBattleState.getFormationIndex()] = -1;
                targetImage1.sprite = null;
				break;
			default:
				print("error with clear target");
				break;
			}
		}
    }
}
