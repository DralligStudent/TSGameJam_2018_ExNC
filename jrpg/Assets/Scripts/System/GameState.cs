using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool battleStart = false;
    bool changedStateToPrebattle = false;

    private BattleManager N_Battle;
    [SerializeField]
    private Transform Player_Pos;

    public EnemyFleet e_Fleet;
    public enum GameStateMachine
    {
        gs_Null,
        gs_StartMenu,
        gs_OnOverworld,
        gs_PreBattle,
        gs_Battle
    };

    public static GameStateMachine GSM;

    //Bools/int for tracking game progress
    //Used for traditional gameState machine.
    private int gameProgress = 0;
    private bool placeholderProgress1 = false;
    private bool placeholderProgress2 = false;
    //etc...
    
    public static void SwitchState(int newState)
    {
        switch (newState)
        {
            //null
            case 0:
                GameState.GSM = GameStateMachine.gs_Null;
                break;
            //to title screen
            case 1:
                if (GSM == GameStateMachine.gs_OnOverworld)
                {
                    GameState.GSM = GameStateMachine.gs_StartMenu;
                }
                else
                {
                    Debug.Log("Error. Can't switch game state to start menu.");
                }
                break;
            //to overworld
            case 2:
                if(GSM == GameStateMachine.gs_StartMenu || GSM == GameStateMachine.gs_Battle)
                {
                    GameState.GSM = GameStateMachine.gs_OnOverworld;
                    Debug.Log("State switched to Overworld.");
                    SceneManager.LoadScene("overworldLevel1");
                }
                else
                {               
                    Debug.Log("Error. Can't switch game state to overworld.");
                }
                break;
            //to prebattle
            case 3:
                if (GSM == GameStateMachine.gs_OnOverworld)
                {
                    GameState.GSM = GameStateMachine.gs_PreBattle;
                    Debug.Log("State switched to prebattle.");
                }
                else
                {
                    Debug.Log("Error. Can't switch game state to prebattle.");
                }
                break;
            case 4:
                if (GSM == GameStateMachine.gs_PreBattle)
                {
                    GameState.GSM = GameStateMachine.gs_Battle;
                    Debug.Log("State switched to battle.");
                }
                else
                {
                    Debug.Log("Error. Can't switch game state to battle.");
                }
                break;

            default:
                GameState.GSM = GameStateMachine.gs_Null;
                Debug.Log("Likely bad Argument error. State is now null.");
                break;
        }
    }

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
	void Update ()
    {
        if(SceneManager.GetActiveScene().name == "prebattleScene" && !changedStateToPrebattle)
        {
            GameState.SwitchState((int)GameState.GameStateMachine.gs_PreBattle);
            changedStateToPrebattle = true;
        }
        switch (GSM)
        {
            case GameStateMachine.gs_Null:
                break;

            case GameStateMachine.gs_OnOverworld:
                //Debug.Log("");
                //Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
                break;

            case GameStateMachine.gs_PreBattle:
                if (!isInPreBattle)
                {
                    Debug.Log("We'll recognize this"); Debug.Log(e_Fleet);
                    GameObject.Find("PreBattleState").GetComponent<PreBattleState>().currentEnemyFleet = e_Fleet;
                    //prebattlecontroller.currentEnemyFleet = e_Fleet;
                    GameObject.Find("BattleManagerSystem").GetComponent<BattleManager>().Enemy = e_Fleet;
                    isInPreBattle = true;         
                }
                break;

            case GameStateMachine.gs_Battle:
                if (N_Battle == null && battleStart)
                {

                }
                else
                {
                    //Stuff for the battle. UI maybe?
                }
                break;
        }
	}
}
