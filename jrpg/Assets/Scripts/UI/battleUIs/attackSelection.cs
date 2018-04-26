using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSelection : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public GameObject currentMenu;
    public GameObject actionMenu;

    private int currentSelection;//the currently selected button
    private int numButtons;//total number of buttons

    SpriteRenderer renderer1;
    SpriteRenderer renderer2;
    SpriteRenderer renderer3;
    SpriteRenderer renderer4;

    public Color defaultColour = Color.white;
    public Color selectColour = new Color(0f, 0.7f, 1f, 1f);

    public string currentAction = "null";

    public GameObject targets;//the player or enemy fleet

    private bool active = true;
    public BattleManager bm;


    // Use this for initialization
    void Start ()
    {
        bm = GameObject.Find("BattleManagerSystem").GetComponent<BattleManager>();
        currentSelection = 1;
        numButtons = 4;

        renderer1 = button1.GetComponent<SpriteRenderer>();
        renderer2 = button2.GetComponent<SpriteRenderer>();
        renderer3 = button3.GetComponent<SpriteRenderer>();
        renderer4 = button4.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (active) {
            if (Input.GetKeyDown(KeyCode.W))
                currentSelection--;

            if (Input.GetKeyDown(KeyCode.S))
                currentSelection++;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                actionMenu.SetActive(true);
                currentMenu.SetActive(false);
            }

            if (currentSelection > numButtons)//loops the selection
                currentSelection = 1;
            else if (currentSelection < 1)
                currentSelection = numButtons;

            if (currentSelection == 1)
            {

                renderer1.color = selectColour;
                renderer2.color = defaultColour;
                renderer4.color = defaultColour;
            }
            else if (currentSelection == 2)
            {
                renderer2.color = selectColour;
                renderer1.color = defaultColour;
                renderer3.color = defaultColour;
            }
            else if (currentSelection == 3)
            {
                renderer3.color = selectColour;
                renderer2.color = defaultColour;
                renderer4.color = defaultColour;
            }
            else if (currentSelection == 4)
            {
                renderer4.color = selectColour;
                renderer1.color = defaultColour;
                renderer3.color = defaultColour;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentSelection == 1)//the player selected the first action
                {
                    currentAction = "AttackSelect1";//this needs to tell the gamemanager what attack to do
                }
                else if (currentSelection == 2)
                {
                    currentAction = "AttackSelect2";
                }
                else if (currentSelection == 3)
                {
                    currentAction = "AttackSelect3";
                }
                else if (currentSelection == 4)
                {
                    currentAction = "AttackSelect4";
                }
                //select the target
                targets.SetActive(true);//sets active the target fleet
                active = false;//stops the player from controlling this screen while hes selecting an enemy
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            targets.SetActive(false);
            active = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && active == false)
        {
            active = true;
            targets.SetActive(false);
            currentMenu.SetActive(false);
            actionMenu.SetActive(true);

        }
    }
}
