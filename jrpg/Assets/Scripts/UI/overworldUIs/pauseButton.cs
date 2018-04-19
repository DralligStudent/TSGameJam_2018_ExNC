using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour {

    public GameObject pauseMenu;

    public GameObject pauseMenuBackground;
    public Animator backAnim;//the animator for the background
    public GameObject buttons;
    public Animator buttonAnim;

    public GameObject player;
    public moveOnGrid playerScript;

    // Use this for initialization
    void Start () {
        backAnim = pauseMenuBackground.GetComponent<Animator>();
        buttonAnim = buttons.GetComponent<Animator>();

        playerScript = player.GetComponent<moveOnGrid>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            backAnim.SetBool("active", true);
            buttonAnim.SetBool("activeB", true);
            playerScript.enabled = false;//disable player movement when in menu
        }
    }
}
