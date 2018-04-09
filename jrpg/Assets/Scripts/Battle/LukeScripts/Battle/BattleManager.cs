using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{
    
    public PlayerFleet Player;
    public EnemyFleet Enemy;
    
    public bool isActive;
    protected TurnAction[] Turns;
    public GameObject[] P_Ship_Array;
    public GameObject[] E_Ship_Array;
    public GameObject active_Ship;

    private bool set_Action = false;

    
    public enum attack_Choice
    {
        Null = 0,
        A,
        B,
        C,
        D
    };

    public enum defense_Choice
    {
        Null = 0,
        A,
        B,                                                  //DOES ANY OF THESE ENUMS ACTUALLY GET USED? NEED TO FINALISE THE BLOODY ATTACK SYSTEM AND HOW THAT WORKS ******** YE WE NEED THIS DUDE
        C,
        D
    };

    public enum equipment_Choice
    {
        Null = 0,
        A,
        B,
        C,
        D
    };

    public enum battle_State
    {
        Null = 0,
        PlayerTurn,
        ActionPhase,
        Loss,
        Win
    };

    attack_Choice a_Choice = attack_Choice.Null;
    defense_Choice d_Choice = defense_Choice.Null;
    equipment_Choice e_Choice = equipment_Choice.Null;

    battle_State c_Battle = battle_State.Null;

    /*
    _Ship rat;
    _Ship mouse;
    */

    public BattleManager(PlayerFleet p_Fleet, EnemyFleet e_Fleet)
    {
        Player = p_Fleet;
        Enemy = e_Fleet;

        P_Ship_Array = new GameObject[Player.get_FleetSize()];
        P_Ship_Array = Player.get_Fleet();

        E_Ship_Array = new GameObject[Enemy.get_FleetSize()];
        E_Ship_Array = Enemy.get_Fleet();
    }

    // Use this for initialization
    void Start()
    {
        c_Battle = battle_State.PlayerTurn;



        /*
        Turns = new TurnAction[1];
        Ship_Array = new _Ship[2];
        */
        //rat = GameObject.Find("Rat").GetComponent<Rat_Ship>();
        //mouse = GameObject.Find("Mouse").GetComponent<Rat_Ship>();
        /*
        Ship_Array[0] = rat;
        Ship_Array[1] = mouse;*/
        //TurnAction turn = new TurnAction(rat, mouse, rat.s_Get_Weapon((int)attack_Choice.A));
        //Turns[0] = turn;
        //Array.Sort(Ship_Array, delegate (_Ship x, _Ship y) { return x.s_Get_Speed().CompareTo(y.s_Get_Speed()); });
    }

    /*void b_Turn(_Ship a_Ship, _Ship t_Ship, attack_Choice a_Action)
    {
        _Weapon cur_Wep = a_Ship.s_Get_Weapon((int)a_Action); //cast as int performance issue minimal in turn based combat
        int c_Dam_S = cur_Wep.w_Get_Dam_S();
        int c_Dam_H = cur_Wep.w_Get_Dam_H();

        if (t_Ship.s_Get_Shields() < 0)
        {
            t_Ship.s_Take_Damage(c_Dam_H, true);
        }
        else
        {
            t_Ship.s_Take_Damage(c_Dam_S, false);
        }
    }*/



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
        /*
         */
        b_Pre_Action_Call();//this triggers actions before turn choices
        b_Action_Set();//turn choices are made


        for (int i = 0; i < P_Ship_Array.Length; i++)
        {
            /*
             * THIS IS WHERE THE UI IS NEEDED SO I CAN SET THE RIGHT THINGS THAT I CANT THINK OF RIGHT NOW
             */
            //b_Set_Turn()

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

        foreach (GameObject G in P_Ship_Array)
        {
            active_Ship = G;
            set_Action = false;
            if (set_Action == false)
            {

            }
            set_Action = true;
        }

        /*foreach (TurnAction a in Turns)
        {
            a.Action();
        }*/

        b_Post_Action_Call();


        if (E_Ship_Array.Length == 0)
        {
            c_Battle = battle_State.Win;
        }


        /*
         * Stall the script until it is called again, managing the battle flow.
         * 
         * 
         * 
         * 
         */
    }

    void b_Set_Turn()
    {
        /*
         * Set the active ship in ui
         */
        //Active ship should already be set to the next ship in the speed list.


        /*
         * Take the option for the ship 
         * Some Ui code for selecting the thing
         * 
         */



        /*
         * Create a turnaction and add to the que of turns.
         */




        //var i_Choice = 

        //switch (i_Choice)
        //case attack_Choice

        /*
        TurnAction n_Turn; //define the turn
        int x; //define its position
        Turns[x] = n_Turn; //add to array of turns
        */


    }

    void b_Speed_Sort()
    {
        /*
         * This is where the sorting of the ship speed should be done. WWOW What a task
         * 
         */
    }

    void b_Pre_Action_Call()
    {
        //place things within this function so that these actions take place prior to any other action in a turn. for example shield recharge
    }

    void b_Post_Action_Call()
    {
        //Place things within this function so that these actions take place post any action within a turn. for example DOT calculations
    }

    void b_Action_Set()
    {
        //Function used to set all the player actions
        
        
        
        
        
        
        
        //TurnAction n_Turn = new TurnAction(active_Ship, )
    }

    void b_Win_Conditions()
    {
        //function used to check every win/loss condition
    }
}