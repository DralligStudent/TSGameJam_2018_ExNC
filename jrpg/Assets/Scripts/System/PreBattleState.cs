using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * A class to hold/contain data related to the Pre-Battle system. It holds the "Formation" set by the player between battles
 * so that they don't have to keep setting the fleet every battle, and can swap them out instead.
 */

public class PreBattleState : MonoBehaviour {

    //Static object creation.
    public static PreBattleState m_PreBattleState;
    public gameObject battleSystem;

    //GameState machine will toggle this bool. Meant to keep the class from running the update loop needlessly outside of pre-battle.
    public static bool isPreBattleActive = false;
    //Since this class is static, awake/start only run once, ever. We only want some things run once a battle for setup. This bool helps control that.
    public static bool newBattle = false;

    public bool isReady = false;

    private int commandLevel;
    private int fleetPoints;

    private int formationIndex;
    private int inventoryIndex;

    int fleetSize = 5;

    //Container of key values that is passed to the battle system.
    //The index of battleFormation also refers to the formation slot used.
    //The index contains values which reference the index that contains the relevent ship in the player's inventory.
    int[] battleFormation = new int[5];

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
	
    void setBattleFormation()
    {
        battleFormation[formationIndex] = inventoryIndex;
    }

    //UI can call this function with a send message.
    void setFormationIndex(int newFormationIndex)
    {
        formationIndex = newFormationIndex;
    }

    void setInventoryIndex(int newInventoryIndex)
    {
        inventoryIndex = newInventoryIndex;
    }

    void CalcFleetPoints()
    {
        //Placeholder values.
        commandLevel = PlayerCommander.GetLevel();
        fleetPoints = commandLevel * 100;
    }

    void SetBattleFormation()
    {
        for (int i = 0; i < fleetSize; i++)
        {
            battleFormation[i] = formationSetup[i];
        }
    }


    //Boolean toggles

    //GameState is meant to be able to use this.
    void PreBattleActiveToggle()
    {
        isPreBattleActive = !isPreBattleActive;
    }
    //And this.
    void NewBattleToggle()
    {
        newBattle = !newBattle;
    }

    //To be called from a UI selection.
    void ReadyToggle()
    {
        isReady = !isReady;
    }



    // Update is called once per frame
    void Update () {



		if (isPreBattleActive)
        {
            if (newBattle)
            {

                CalcFleetPoints();
                NewBattleToggle();
            }
        }

        if (isReady)
        {
            //Send relevent information to battle system/GameState
            //Structure of Ships?
            battleSystem.SendMessage("SetFormation", battleFormation);


            isPreBattleActive = false;
            isReady = false;
        }

	}
}
