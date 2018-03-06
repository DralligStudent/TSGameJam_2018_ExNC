using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleeSelection : MonoBehaviour
{

    public GameObject yesButton;//the two buttons
    public GameObject noButton;

    public GameObject currentMenu;//the menus
    public GameObject actionMenu;

    private int currentSelection;//the currently selected button
    private int numButtons;//total number of buttons

    SpriteRenderer yesRenderer;//the button renderers
    SpriteRenderer noRenderer;

    public Color defaultColour = Color.white;//the default colour of the buttons
    public Color selectColour = new Color(0f, 0.7f, 1f, 1f);//the colour the buttons will be when currently selected


    // Use this for initialization
    void Start()
    {
        currentSelection = 1;
        numButtons = 2;

        yesRenderer = yesButton.GetComponent<SpriteRenderer>();//gets the button renderers
        noRenderer = noButton.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (currentSelection == 1)//renders the colours the correct colours if yes is currently selected
        {
            yesRenderer.color = selectColour;
            noRenderer.color = defaultColour;
        }
        else if (currentSelection == 2)
        {
            noRenderer.color = selectColour;
            yesRenderer.color = defaultColour;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentSelection == 1)
            {
                //begin flee sequence
            }
            else if (currentSelection == 2)
            {
                actionMenu.SetActive(true);//enables the action menu
                currentMenu.SetActive(false);//disables the flee menu
            }
        }
    }
}
