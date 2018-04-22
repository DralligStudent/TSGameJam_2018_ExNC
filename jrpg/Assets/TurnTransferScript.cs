using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTransfer : MonoBehaviour
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
        BM = GameObject.Find("BattleManageSystem").GetComponent<BattleManager>();
        AM = GameObject.Find("actionSelection").GetComponent<actionMenu>();
        AS = GameObject.Find("attakSelection").GetComponent<attackSelection>();
        TS = GameObject.Find("enemies").GetComponent<targetSelect>();
    //BM = GameObject.Find("BattleManageSystem");
        current_Ship = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        grab_Scripts();
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
            BM.CurrentTurn.t_Ship = BM.E_Ship_Array[TS.currentSelection];
            
        }

	}

    void AMStat()
    {
        BM.CurrentTurn.c_Action = TurnAction.action_Type.Weapon;
    }

    void ASWepSet()
    {
        if (AS.currentAction == "placeholder1")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<_Ship>().s_Get_Weapon(0);
        }
        if (AS.currentAction == "placeholder2")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<_Ship>().s_Get_Weapon(1);
        }
        if (AS.currentAction == "placeholder3")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<_Ship>().s_Get_Weapon(2);
        }
        if (AS.currentAction == "placeholder4")
        {
            BM.CurrentTurn.c_Wep = BM.P_Ship_Array[current_Ship].GetComponent<_Ship>().s_Get_Weapon(3);
        }
    }

    void grab_Scripts()
    {

    }
}
