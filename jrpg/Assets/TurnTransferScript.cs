using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTransferScript : MonoBehaviour
{
    public int current_Ship;
    public enum attackState
    {
        ASNull = 0,
        playerSet,
        playerDone
    };

    public attackState currentAttackState = attackState.ASNull;
    public BattleManager BM;
    public actionMenu AM;
    public attackSelection AS;
    public targetSelect TS;
	// Use this for initialization
	void Start ()
    {

        current_Ship = 0;
        //BM.c_Battle = BattleManager.battle_State.PlayerTurn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        grab_Scripts1();
        grab_Scripts2();
        grab_Scripts3();
        grab_Scripts4();
        Debug.Log(AM.attackSelected);
        if (AM.attackSelected != "null")
        {
            AMStat();
            //BM.CurrentTurn.c_Action = TurnAction.action_Type.Weapon;
        }
        else
        {
            return;
        }

        if (AS.currentAction != "null")
        {
            ASWepSet();
        }

        if (TS.Targeted != null)
        {
            BM.CurrentTurn.t_Ship = BM.E_Ship_Array[(int)TS.currentSelection];
            BM.CurrentTurn.t_Ship = BM.E_Ship_Array[TS.c_target];

        }

        if (TS.Targeted != null && AS.currentAction != "null" && AM.attackSelected != "null")
        {
            Debug.Log("Player turn doen");
            AttackDone();
        }


	}
        /*
        BM = GameObject.Find("BattleManagerSystem").GetComponent<BattleManager>();
        Debug.Log("lol");
        AM = GameObject.Find("actionSelection").GetComponent<actionMenu>();
        Debug.Log(AM.attackSelected);
        AS = GameObject.Find("attackSelection").GetComponent<attackSelection>();
        TS = GameObject.Find("enemies").GetComponent<targetSelect>();*/
    //BM = GameObject.Find("BattleManageSystem");
    void AMStat()
    {
        Debug.Log("Is this called");
        Debug.Log(BM.CurrentTurn.c_Action);
        BM.CurrentTurn.c_Ship = BM.P_Ship_Array[current_Ship];
        BM.CurrentTurn.c_Action = TurnAction.action_Type.Weapon;
        Debug.Log(BM.CurrentTurn.c_Action);
        //AM.attackSelected = "null";
    }

    void ASWepSet()
    {
        if (AS.currentAction == "AttackSelect1")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<publicShip>().ShipClass.s_Get_Weapon(0);
        }
        if (AS.currentAction == "AttackSelect2")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<publicShip>().ShipClass.s_Get_Weapon(1);
        }
        if (AS.currentAction == "AttackSelect3")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<publicShip>().ShipClass.s_Get_Weapon(2);
        }
        if (AS.currentAction == "AttackSelect4")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<publicShip>().ShipClass.s_Get_Weapon(3);
        }
    }

    void AttackDone()
    {
        currentAttackState = attackState.playerSet;
        AM.attackSelected = "null";
        AS.currentAction = "null";
        TS.Targeted = null;
    }

    void grab_Scripts1()
    {
        Debug.Log("Grabbin");
        if (!BM)
        {
            Debug.Log("i get called");
            BM = GameObject.Find("BattleManagerSystem").GetComponent<BattleManager>();
            //BM.c_Battle = BattleManager.battle_State.PlayerTurn;
        }            
    }

    void grab_Scripts2()
    {
        if (!AM)
        {
            AM = GameObject.Find("actionSelection").GetComponent<actionMenu>();
        }
    }
    void grab_Scripts3()
    {
        if (!AS && GameObject.Find("attackSelection"))
        {
            AS = GameObject.Find("attackSelection").GetComponent<attackSelection>();
        }
    }
    void grab_Scripts4()
    {
        if (!TS && GameObject.Find("enemies"))
        {
            //if(GameObject.Find("enemies"))
            TS = GameObject.Find("enemies").GetComponent<targetSelect>();
        }
    }
}
