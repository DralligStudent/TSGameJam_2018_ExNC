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
    //Player ship inventory/inventory.
    public GameObject playerHanger;
    //GameState machine will toggle this bool. Meant to keep the class from running the update loop needlessly outside of pre-battle.
    public static bool isPreBattleActive = false;
    //Since this class is static, awake/start only run once, ever. We only want some things run once a battle for setup. This bool helps control that.
    public static bool newBattle = false;

    public bool isReady = false;

    private int commandLevel;
    private int fleetPoints;

    int fleetSize = 5;

    //Container for fleet formations?
    IDictionary<int, int[]> formations = new Dictionary<int, int[]>();

    //temp container for fleets.
    int[] formationSetup = new int[5];
    //Container of key values that is passed to the battle system.
    //These key values will be references to the player's hanger, to let the battle system know which ships to put into play.
    int[] battleFormation = new int[5];

    //IDictionary<int, Ship> playerShips = new Dictionary<int, Ship>();
    /*
    IDictionary<int, string> rowCapital;
    IDictionary<int, string> rowBattleship;
    IDictionary<int, string> rowCruiser;
    IDictionary<int, string> rowDestroyer;
    IDictionary<int, string> rowFighter;
    */

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

            isPreBattleActive = false;
            isReady = false;
        }

	}
}
