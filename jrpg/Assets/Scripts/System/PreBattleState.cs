using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * A class to hold/contain data related to the Pre-Battle system. It holds the "Formation" set by the player between battles
 * so that they don't have to keep setting the fleet every battle, and can swap them out instead.
 * Future improvement: Save slots for formations.
 */

public class PreBattleState : MonoBehaviour {

    //Static object creation.
    public static PreBattleState m_PreBattleState;
    public GameObject battleSystem;

    bool alreadycalled = false;

    PlayerInventory m_player_inven;

    //Since this class is static, awake/start only run once, ever. We only want some things run once a battle for setup. This bool helps control that.
    public static bool newBattle = false;
    public bool isReady = false;

    public _Fleet currentPlayerFleet;

    public EnemyFleet currentEnemyFleet;

    private int commandLevel;
    private int fleetPoints;

    private int formationIndex;
    private int inventoryIndex;

    const int fleetSize = 9;

    //Container of key values that is passed to the battle system.
    //The index of battleFormation also refers to the formation slot used.
    //The index contains values which reference the index that contains the relevent ship in the player's inventory.
    public int[] battleFormation = new int[9];


    public int getFormationIndex()
    {
        return formationIndex;
    }

    //UI can call this function with a send message.
    //Selects a formation slot.
    public void setFormationIndex(int newFormationIndex)
    {
        formationIndex = newFormationIndex;
    }

    //Function to select the index in the ship inventory of the ship we want.
    //We'll put this data(the inventory index) into the battleformation array.
    //tldr Selects a ship. (Give the inventory index where the ship is in the player's ship inventory)
    public void setInventoryIndex(int newInventoryIndex)
    {
        inventoryIndex = newInventoryIndex;
    }

    //Assigns data to the battleformation array based on the selected formation slot.
    //tldr puts a selected ship into the formation at the spot the player picked.
    public void setBattleFormation()
    {
        battleFormation[formationIndex] = inventoryIndex;
    }

    //To be called from a UI selection.
    public void ReadyToggle()
    {
        isReady = !isReady;
    }

    void CalcFleetPoints()
    {
        //Placeholder values.
        commandLevel = PlayerCommander.GetLevel();
        fleetPoints = commandLevel * 100;
    }

    public void CreateFleet()
    {
        for (int i = 1; i < fleetSize; i++)
        {
            int testint = battleFormation[i];
            Debug.Log(battleFormation[i]);

            GameObject testobject = m_player_inven.AccessShip(testint);
            if (battleFormation[i] != 0)
            {
                currentPlayerFleet._Add_To_Fleet(testobject);
            }
        }
    }

    //Boolean toggles

    //Toggles in GameState.
    void PreBattleActiveToggle()
    {
        GameState.isInPreBattle = !GameState.isInPreBattle;
    }
    //And this.
    void NewBattleToggle()
    {
        newBattle = !newBattle;
    }

    //Since this class/script is meant to hold data in-between other happenings/levels, we don't want it destroyed.
    //Singleton design.
    private void Awake()
    {
        if (m_PreBattleState == null)
        {
            m_PreBattleState = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        m_player_inven = GameObject.Find("P_Inven").GetComponent<PlayerInventory>();
        
        currentPlayerFleet = this.gameObject.AddComponent<_Fleet>();
        //currentPlayerFleet.
        Debug.Log(currentPlayerFleet);
    }
	
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(battleFormation[1]);
        }

        if (GameState.isInPreBattle)
        {
            if (newBattle)
            {
                CalcFleetPoints();
                NewBattleToggle();
            }

            if (isReady)
            {
                //Sends info to battle system and resets booleans, shutting off pre-battle state.
                //Future improvements: Adding a confirm
                ReadyToggle();
                NewBattleToggle();
                if (!alreadycalled)
                {
                    CreateFleet();
                    alreadycalled = true;
                    Debug.Log(alreadycalled);
                }
                PreBattleActiveToggle();
                SceneManager.LoadScene("battleScene");
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PreBattleActiveToggle();
            //Debug.Log(battleFormation[1]);
        }
    }
}
