using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public static GameState m_GameState;
    //Bools for tracking game status
    //Why? --> This information can allow us to pause/skip update loops of objects that aren't needed at the time
    //Especially those that persist though scene changes.
    public static bool isOnStartScreen = true;
    public static bool isOnMenu = false;
    public static bool isPaused = false;
    public static bool isOnOverworld = false;
    public static bool isInPreBattle = false;
    public static bool isInBattle = false;
    //Bools/int for tracking game progress
    //Used for traditional gameState machine.
    private int gameProgress = 0;
    private bool placeholderProgress1 = false;
    private bool placeholderProgress2 = false;
    //etc...
    
    //Creates the game manager, singleton design
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
