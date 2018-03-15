using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * A class to hold/contain data related to the Pre-Battle system. It holds the "Formation" set by the player between battles
 * so that they don't have to keep setting the fleet every battle, and can swap them out instead.
 * Future improvement: Save slots for formations.
 */

public class PreBattleState : MonoBehaviour {

    //Static object creation.
    public static PreBattleState m_PreBattleState;
    public GameObject battleSystem;

    //Since this class is static, awake/start only run once, ever. We only want some things run once a battle for setup. This bool helps control that.
    public static bool newBattle = false;
    public bool isReady = false;

    public PlayerFleet currentPlayerFleet;
    public EnemyFleet currentEnemyFleet;

    private int commandLevel;
    private int fleetPoints;

    private int formationIndex;
    private int inventoryIndex;

    int fleetSize = 10;

    //Container of key values that is passed to the battle system.
    //The index of battleFormation also refers to the formation slot used.
    //The index contains values which reference the index that contains the relevent ship in the player's inventory.
    int[] battleFormation = new int[10];

    //UI can call this function with a send message.
    void setFormationIndex(int newFormationIndex)
    {
        formationIndex = newFormationIndex;
    }

    void setInventoryIndex(int newInventoryIndex)
    {
        inventoryIndex = newInventoryIndex;
    }

    void setBattleFormation()
    {
        battleFormation[formationIndex] = inventoryIndex;
    }

    //To be called from a UI selection.
    void ReadyToggle()
    {
        isReady = !isReady;
    }

    void CalcFleetPoints()
    {
        //Placeholder values.
        commandLevel = PlayerCommander.GetLevel();
        fleetPoints = commandLevel * 100;
    }

    void CreateFleet()
    {
        for (int i = 0; i < fleetSize; i++)
        {
            currentPlayerFleet._Add_To_Fleet(PlayerInventory.m_Player_Inventory.AccessShip(battleFormation[i]));
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

    }
	
    // Update is called once per frame
    void Update () {

        if (GameState.isInPreBattle)
        {
            if (newBattle)
            {
                CalcFleetPoints();
                NewBattleToggle();
            }

            //Sends info to battle system and resets booleans, shutting off pre-battle state.
            //Future improvements: Adding a confirm
            if (isReady)
            {
                PreBattleActiveToggle();
                ReadyToggle();
                NewBattleToggle();
                //loadscene
            }
        }
	}
}
