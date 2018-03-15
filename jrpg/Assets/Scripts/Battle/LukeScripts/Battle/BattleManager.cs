using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{
    /*
    public PlayerFleet Player;
    public EnemyFleet Enemy;                        //IS FLEET NEEDED? YES
    */
    public bool isActive;
    protected TurnAction[] Turns;
    public GameObject[] Ship_Array;
    public GameObject active_Ship;

    
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

    attack_Choice a_Choice = attack_Choice.Null;
    defense_Choice d_Choice = defense_Choice.Null;
    equipment_Choice e_Choice = equipment_Choice.Null;


    /*
    _Ship rat;
    _Ship mouse;
    */

    public BattleManager(PlayerFleet p_Fleet, EnemyFleet e_Fleet)
    {
        /*
        Player = p_Fleet;
        Enemy = e_Fleet;*/
    }

    // Use this for initialization
    void Start()
    { /*
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
        for (int i = 0; i < Ship_Array.Length; i++)
        {
            /*
             * THIS IS WHERE THE UI IS NEEDED SO I CAN SET THE RIGHT THINGS THAT I CANT THINK OF RIGHT NOW
             */
            //b_Set_Turn()

        }

        /*foreach (TurnAction a in Turns)
        {
            a.Action();
        }*/
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
}