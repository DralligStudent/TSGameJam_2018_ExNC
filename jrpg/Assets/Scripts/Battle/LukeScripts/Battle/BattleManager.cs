using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleManager : MonoBehaviour
{

    public PlayerFleet Player;
    public EnemyFleet Enemy;

    public bool isActive; //used to set the turn going, allows for
    protected TurnAction[] Turns;
    public GameObject[] P_Ship_Array;
    public GameObject[] E_Ship_Array;
    public GameObject active_Ship;
    private GameObject en_Ship;

    private bool set_Action = false;
    private bool x = false;

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
        ActionPhase,
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

    battle_State c_Battle = battle_State.bNull;

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
        //c_Battle = battle_State.PlayerTurn;
        c_Battle = battle_State.PrePhase;



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
        Debug.Log("xyz");
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

        StartCoroutine(b_Set_Turn());

        foreach (GameObject G in P_Ship_Array) //need to set a system of pause for this, ienumerator
        {
            active_Ship = G;
            set_Action = false;
            if (set_Action == false)
            {
                Debug.Log("xyz");
                StartCoroutine(b_Set_Turn());
            }
            set_Action = true;
        }

        /*foreach (TurnAction a in Turns)
        {
            a.Action(); //run the action.
            StartCoroutine(b_Turn_Anim_Timer()); 
            /*play a timer, used so that an animation can play.
             * this means that when finalised, a function for animations should go here
             * the reason ive chosen this route over others is so that the calculations are only done 
             * when needed in the turn resolution, rather than having to keep a 
             * hold of the changes throughout the battle elsewhere the changes 
             * only happen when they need to.
             * 
            */
        //}*/

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
        /*
       StartCoroutine(b_Turn_Anim_Timer());
       b_Update_Hold();
       StartCoroutine(b_test());*/
        /*techincally this is redundant, as nothing of note needs to happen here, and the loop can continue. however should i need to hold i have the function
         * 
         */
    }

    IEnumerator b_Set_Turn()
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
        Debug.Log("terst");

        while (at_Choice == e_Choice.eNull || de_Choice == e_Choice.eNull || eq_Choice == e_Choice.eNull)
        {
            Debug.Log("terst1");
            yield return null;
            //b_Turn_Hold(); //replace this with a yield for ui input that sets the attack choice



            /*
            if (at_Choice != e_Choice.eNull)
            {
                t_Set = t_Choice.attack
            }*/
        }

        if (at_Choice != e_Choice.eNull)
        {
            //Wait for ui to select attack

            //wait again for ui to select target

            //Set enemy ship to en_Ship;
        }

        if (de_Choice != e_Choice.eNull)
        {

        }





        switch (t_Set)
        {
            case t_Choice.attack:
                TurnAction nTurn1 = new TurnAction(active_Ship, en_Ship, active_Ship.GetComponent<_Ship>().s_Get_Weapon((int)at_Choice)); //theoretically that works, cant check until later though
                //Turns[x] = nTurn;
                break;

            case t_Choice.defense:
                TurnAction nTurn2 = new TurnAction(active_Ship, active_Ship.GetComponent<_Ship>().s_Shields[0]);
                //add to turn action list
                break;

            case t_Choice.equipment:
                /*TurnAction nTurn3 = new TurnAction(active_Ship,)*/
                break;
        }

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
        yield break;
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

        if (E_Ship_Array.Length == 0)
        {
            c_Battle = battle_State.Win;
        }
    }

    IEnumerator b_test()
    {
        Debug.Log("wasaer");
        while (x == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                x = true;
            }
            yield return null;
        }
        Debug.Log("wasaer2");
    }


    IEnumerator b_Turn_Anim_Timer()
    {
        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator b_Update_Hold()
    {
        yield return new WaitUntil(() => isActive == true);
    }

    IEnumerator b_Turn_Hold()
    {
        yield return null;
    }

    void b_Enemy_Turn()
    {
        foreach (GameObject eShip in E_Ship_Array)
        {//This is where the enemy turns are decided uninteliggently
            _Weapon en_Wep = eShip.GetComponent<_Ship>().s_Get_Weapon(0);
            //Produce random number to pick a player ship to attack
            int rn = UnityEngine.Random.Range(0, P_Ship_Array.Length);
            //produce attack turn
            TurnAction nTurn = new TurnAction(eShip, P_Ship_Array[rn], en_Wep);
        }
    }
}