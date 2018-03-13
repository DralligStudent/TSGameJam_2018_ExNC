using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public static GameState m_GameState;
    //Bools for tracking game status
    private bool isOnStartScreen = true;
    private bool isOnMenu = false;
    private bool isPaused = false;
    private bool isOnOverworld = false;
    private bool isInPreBattle = false;
    private bool isInBattle = false;
    //Bools/int for tracking game progress
    private int gameProgress = 0;
    private bool placeholderProgress1 = false;
    private bool placeholderProgress2 = false;
    //etc...

    //Creates the game manager
    void Awake()
    {
        if (m_GameState == null)
        {
            m_GameState = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
