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
    public _Ship[] Ship_Array;

    public enum attack_Choice
    {
        A = 0,
        B = 1,
        C,
        D
    };

    public enum defense_Choice
    {
        A = 0,
        B,
        C,
        D
    };

    public enum equipment_Choice
    {
        A = 0,
        B,
        C,
        D
    };
    /*
    _Ship rat;
    _Ship mouse;
    */

    public BattleManager(PlayerFleet p_Fleet, EnemyFleet e_Fleet)
    {
        Player = p_Fleet;
        Enemy = e_Fleet;
    }

    // Use this for initialization
    void Start()
    {
        Turns = new TurnAction[1];
        Ship_Array = new _Ship[2];
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



    void b_Get_Weps(_Ship c_Ship)
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (TurnAction a in Turns)
        {
            a.Action();
        }*/
    }

    void b_Set_Turn()
    {
        //var i_Choice = 

        //switch (i_Choice)
            //case attack_Choice

        /*
        TurnAction n_Turn; //define the turn
        int x; //define its position
        Turns[x] = n_Turn; //add to array of turns
        */
    }
}