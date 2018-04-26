using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public PlayerFleet Player;
    public EnemyFleet Enemy;

    public bool isActive; //used to set the turn going, allows for
    protected TurnAction[] Turns;
    public TurnAction CurrentTurn;
    public GameObject[] P_Ship_Array = new GameObject[8];
    public GameObject[] E_Ship_Array = new GameObject[8];
    public GameObject active_Ship;
    public int act_Ship;
    private GameObject en_Ship;
    private TurnAction en_Turn;
    public TurnTransfer TurnTransScript;
    public string thisScene;


    private bool set_Action = false;
    private bool c_Action_Set = false;
    private bool playerSets = false;

    public GameObject aSelect = GameObject.Find("attackSelection");

    public enum e_Choice
    {
        eNull = 0,
        A,
        B,
        C,
        D
    };

    public enum battle_State
    {
        bNull = 0,
        PrePhase,
        PlayerTurn,
        EnemyTurn,
        ActionPhase,
        PostAction,
        Loss,
        Win
    };

    public enum t_Choice
    {
        tNull = 0,
        attack,
        defense,
        equipment
    };

    e_Choice at_Choice = e_Choice.eNull;
    e_Choice de_Choice = e_Choice.eNull;
    e_Choice eq_Choice = e_Choice.eNull;

    t_Choice t_Set = t_Choice.tNull;

    public battle_State c_Battle = battle_State.bNull;

    public BattleManager(PlayerFleet p_Fleet, EnemyFleet e_Fleet)
    {
        Player = p_Fleet;
        Enemy = e_Fleet;

        P_Ship_Array = Player.get_Fleet();
        E_Ship_Array = Enemy.get_Fleet();
    }

    public void setFleets(PlayerFleet p_Fleet, EnemyFleet e_Fleet)
    {
        Player = p_Fleet;
        Enemy = e_Fleet;

        P_Ship_Array = Player.get_Fleet();
        E_Ship_Array = Enemy.get_Fleet();
    }

    // Use this for initialization
    void Start()
    {
        thisScene = SceneManager.GetActiveScene().name;
        //set the length of the ship arrays at or before this point to make sure the turn array is the correct length
        int tLength = P_Ship_Array.Length + E_Ship_Array.Length;
        Turns = new TurnAction[tLength];
    }

    void b_Get_Weps(GameObject c_Ship)
    {
        foreach (_Weapon c_wep in c_Ship.GetComponent<_Ship>().s_Weapons)
        {
            //c_wep. (Set the weapons in UI)
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (thisScene != SceneManager.GetActiveScene().name)
        {
            thisScene = SceneManager.GetActiveScene().name;
        }

        if (TurnTransScript == null && thisScene == "battleScene")
        {
            TurnTransScript = GameObject.Find("TurnHolder").GetComponent<TurnTransfer>();
        }

        if (c_Battle == battle_State.PrePhase)
        {
            b_Pre_Action_Call();
            c_Battle = battle_State.PlayerTurn;
        }

        if (c_Battle == battle_State.PlayerTurn)
        {
            if (TurnTransScript.currentAttackState == TurnTransfer.attackState.playerSet)
            {
                if (CurrentTurn.c_Ship != null && CurrentTurn.c_Wep != null && CurrentTurn.t_Ship != null)
                {
                    Turns[act_Ship] = CurrentTurn;
                    if ((act_Ship + 1) >= P_Ship_Array.Length)
                    {
                        TurnTransScript.currentAttackState = TurnTransfer.attackState.playerDone;
                        c_Battle = battle_State.EnemyTurn;
                    }
                    else
                    {
                        act_Ship++;
                        TurnTransScript.current_Ship = act_Ship;
                        CurrentTurn.c_Ship = null;
                        CurrentTurn.c_Wep = null;
                        CurrentTurn.t_Ship = null;
                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("Cheat win go");
            foreach (GameObject G in E_Ship_Array)
            {
                G.GetComponent<_Ship>().s_Take_Damage(100000000, true);
                c_Battle = battle_State.Win;
            }
        }
        
        if (c_Battle == battle_State.EnemyTurn && TurnTransScript.currentAttackState == TurnTransfer.attackState.playerDone)
        {
            b_Enemy_Turn();
            c_Battle = battle_State.ActionPhase;
        }

        if (c_Battle == battle_State.ActionPhase)
        {
            run_Actions();
            c_Battle = battle_State.PostAction;
        }

        if (c_Battle == battle_State.PostAction)
        {
            b_Post_Action_Call();
            b_Win_Conditions();
        }

        if (c_Battle == battle_State.Win)
        {
            //win code here
        }

        if (c_Battle == battle_State.Loss)
        {
            //loss code here
        }

    }

    void b_Pre_Action_Call()
    {
        //place things within this function so that these actions take place prior to any other action in a turn. for example shield recharge
    }

    void b_Post_Action_Call()
    {
        //Place things within this function so that these actions take place post any action within a turn. for example DOT calculations
    }

    void run_Actions()
    {
        foreach (TurnAction TA in Turns)
        {
            TA.Action();
            b_Turn_Anim_Timer();
            //here we can add in real animations rather than a standard turn timer
        }
    }

    void b_Win_Conditions()
    {
        //function used to check every win/loss condition
        if (E_Ship_Array.Length == 0)
        {
            c_Battle = battle_State.Win;
        }
        else if(P_Ship_Array.Length == 0)
        {
            c_Battle = battle_State.Loss;
        }
    }

    IEnumerator b_Turn_Anim_Timer() //this timer is used to temporarily pause the script, will later be altered for animation length in battle
    {
        yield return new WaitForSeconds(3.0f);
    }

    void b_Enemy_Turn()
    {
        foreach (GameObject eShip in E_Ship_Array)
        {
            //This is where the enemy turns are decided uninteliggently(not predictable)
            //Set a random int to define a random weapon to use in this turn
            int rw = UnityEngine.Random.Range(0, eShip.GetComponent<_Ship>().s_Weapons.Length);
            //set the random weapon
            _Weapon en_Wep = eShip.GetComponent<publicShip>().ShipClass.s_Get_Weapon(rw);
            //Produce random number to pick a player ship to attack
            int rs = UnityEngine.Random.Range(0, P_Ship_Array.Length);
            //add a turn to the turn holder to manipulate
            TurnAction nturn = GameObject.Find("TurnHolder").AddComponent<TurnAction>();
            //set the values in the new turn
            nturn.c_Ship = eShip;
            nturn.t_Ship = P_Ship_Array[rs];
            nturn.c_Wep = en_Wep;
            nturn.c_Action = TurnAction.action_Type.Weapon;
            //loop through the turn array. find the first null slot and add it in.
            for (int i = 0; i > Turns.Length; i++)
            {
                if(Turns[i] == null)
                {
                    Turns[i] = nturn;
                    break;
                }
            }
        }
    }
}