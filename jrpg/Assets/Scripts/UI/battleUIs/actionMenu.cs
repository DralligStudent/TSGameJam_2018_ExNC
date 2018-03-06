using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//you need this when using SceneManager

public class actionMenu : MonoBehaviour
{

    public GameObject attack;//the buttons
    public GameObject defence;
    public GameObject special;
    public GameObject flee;

    private int currentSelection;//the currently selected button
    private int numButtons;//total number of buttons

    SpriteRenderer attackSpriteRenderer;
    SpriteRenderer defenceSpriteRenderer;
    SpriteRenderer specialSpriteRenderer;
    SpriteRenderer fleeSpriteRenderer;

    public GameObject actionSelection;
    public GameObject attackSelection;//the different menus
    public GameObject defenceSelection;
    public GameObject specialSelection;
    public GameObject fleeSelection;

    public Color defaultColour = Color.white;
    public Color selectColour = new Color(0f, 0.7f, 1f, 1f);

    // Use this for initialization
    void Start()
    {
        currentSelection = 1;
        numButtons = 4;

        attackSpriteRenderer = attack.GetComponent<SpriteRenderer>();
        defenceSpriteRenderer = defence.GetComponent<SpriteRenderer>();
        specialSpriteRenderer = special.GetComponent<SpriteRenderer>();
        fleeSpriteRenderer = flee.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            currentSelection--;

        if (Input.GetKeyDown(KeyCode.S))
            currentSelection++;

        if (currentSelection > numButtons)//loops the selection
            currentSelection = 1;
        else if (currentSelection < 1)
            currentSelection = numButtons;

        if (currentSelection == 1)
        {
            attackSpriteRenderer.color = selectColour;
            defenceSpriteRenderer.color = defaultColour;
            fleeSpriteRenderer.color = defaultColour;
        }
        else if (currentSelection == 2)
        {
            defenceSpriteRenderer.color = selectColour;
            attackSpriteRenderer.color = defaultColour;
            specialSpriteRenderer.color = defaultColour;
        }
        else if (currentSelection == 3)
        {
            specialSpriteRenderer.color = selectColour;
            defenceSpriteRenderer.color = defaultColour;
            fleeSpriteRenderer.color = defaultColour;
        }
        else if (currentSelection == 4)
        {
            fleeSpriteRenderer.color = selectColour;
            attackSpriteRenderer.color = defaultColour;
            specialSpriteRenderer.color = defaultColour;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentSelection == 1)
            {
                //loads attack menu
                attackSelection.SetActive(true);
                actionSelection.SetActive(false);
            }
            else if (currentSelection == 2)
            {
                //loads defence menu
                defenceSelection.SetActive(true);
                actionSelection.SetActive(false);
            }
            else if (currentSelection == 3)
            {
                //loads special menu
                specialSelection.SetActive(true);
                actionSelection.SetActive(false);
            }
            else if (currentSelection == 4)
            {
                //loads flee menu
                fleeSelection.SetActive(true);
                actionSelection.SetActive(false);
            }
        }
    }
}
