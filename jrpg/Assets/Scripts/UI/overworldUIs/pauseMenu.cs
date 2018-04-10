using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour {

    private int currentSelection;//the currently selected button
    private int numButtons;//total number of buttons

    public GameObject button1, button2, button3, button4, button5, button6;
    public GameObject button1a, button2a, button3a, button4a, button5a, button6a;
    private Image image1, image2, image3, image4, image5, image6;

    public Sprite unselected;
    public Sprite selected;

    public GameObject PauseMenu;
    public Animator anim;

    public GameObject player;
    public moveOnGrid playerScript;

    private float startTime;//the time the menu is enabled
    private float loadTime;//the ammount of time to wait before enabling the buttons

    // Use this for initialization
    void Start () {
        currentSelection = 1;
        numButtons = 6;

        image1 = button1.GetComponent<Image>();
        image2 = button2.GetComponent<Image>();
        image3 = button3.GetComponent<Image>();
        image4 = button4.GetComponent<Image>();
        image5 = button5.GetComponent<Image>();
        image6 = button6.GetComponent<Image>();

        playerScript = player.GetComponent<moveOnGrid>();
    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        loadTime = Time.time - startTime;

        if (Input.GetKeyDown(KeyCode.W))
            currentSelection--;

        if (Input.GetKeyDown(KeyCode.S))
            currentSelection++;

        if (currentSelection > numButtons)//loops the selection
            currentSelection = 1;
        else if (currentSelection < 1)
            currentSelection = numButtons;

        //if (currentSelection == 1)
        //{
        //    image1.sprite = selected;
        //    image6.sprite = unselected;
        //    image2.sprite = unselected;
        //    //button1.GetComponent<Animation>().Play("buttonActivateAnimation");
        //}
        //else if (currentSelection == 2)
        //{
        //    image2.sprite = selected;
        //    image1.sprite = unselected;
        //    image3.sprite = unselected;
        //}
        //else if (currentSelection == 3)
        //{
        //    image3.sprite = selected;
        //    image2.sprite = unselected;
        //    image4.sprite = unselected;
        //}
        //else if (currentSelection == 4)
        //{
        //    image4.sprite = selected;
        //    image3.sprite = unselected;
        //    image5.sprite = unselected;
        //}
        //else if (currentSelection == 5)
        //{
        //    image5.sprite = selected;
        //    image4.sprite = unselected;
        //    image6.sprite = unselected;
        //}
        //else if (currentSelection == 6)
        //{
        //    image6.sprite = selected;
        //    image5.sprite = unselected;
        //    image1.sprite = unselected;
        //}

        if (loadTime>1.5)
        {
            if (currentSelection == 1)
            {
                button1a.SetActive(true);
                button6a.SetActive(false);
                button2a.SetActive(false);
                //button1a.GetComponent<Animation>().Play();
            }
            else if (currentSelection == 2)
            {
                button2a.SetActive(true);
                button1a.SetActive(false);
                button3a.SetActive(false);
            }
            else if (currentSelection == 3)
            {
                button3a.SetActive(true);
                button2a.SetActive(false);
                button4a.SetActive(false);
            }
            else if (currentSelection == 4)
            {
                button4a.SetActive(true);
                button3a.SetActive(false);
                button5a.SetActive(false);
            }
            else if (currentSelection == 5)
            {
                button5a.SetActive(true);
                button4a.SetActive(false);
                button6a.SetActive(false);
            }
            else if (currentSelection == 6)
            {
                button6a.SetActive(true);
                button5a.SetActive(false);
                button1a.SetActive(false);
            }
        }
        else
        {
            button1a.SetActive(false);
            button2a.SetActive(false);
            button3a.SetActive(false);
            button4a.SetActive(false);
            button5a.SetActive(false);
            button6a.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentSelection == 1)
            {
                //resume the game
                Time.timeScale = 1.0f;
                //anim.SetBool("active", false);
                playerScript.enabled = true;//enable player movement after leaving menu
                PauseMenu.SetActive(false);
                
            }
            else if (currentSelection == 2)
            {
                //load player stats
            }
            else if (currentSelection == 3)
            {
                //load inventory
            }
            else if (currentSelection == 4)
            {
                //load options
            }
            else if (currentSelection == 5)
            {
                //save the game
            }
            else if (currentSelection == 6)
            {
                //quit to menu
                Time.timeScale = 1.0f;
                //anim.SetBool("active", false);
                playerScript.enabled = true;//enable player movement after leaving menu
                SceneManager.LoadScene("mainMenu");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //resume the game
            Time.timeScale = 1.0f;
            //anim.SetBool("active", false);
            playerScript.enabled = true;//enable player movement after leaving menu
            PauseMenu.SetActive(false);
        }
    }
}
