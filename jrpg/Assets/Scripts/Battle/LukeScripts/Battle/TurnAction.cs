using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAction : MonoBehaviour
{
    public GameObject c_Ship;
    public GameObject t_Ship;
    public _Weapon c_Wep;
    public _Shield c_Shield;
    public _Engine c_Eng;
    public _Equipment c_Equ;

    public enum action_Type
    {
        Weapon = 0,
        Shield,
        Engine,
        Equipment
    };

    public action_Type c_Action;

    public TurnAction(GameObject active_Ship, GameObject target_Ship, _Weapon a_Weapon)
    {
        c_Ship = active_Ship;
        t_Ship = target_Ship;
        c_Wep = a_Weapon;
        c_Action = action_Type.Weapon;
    }

    public TurnAction(GameObject active_Ship, _Shield a_Shield)
    {
        c_Ship = active_Ship;
        c_Shield = a_Shield;
        c_Action = action_Type.Shield;
    }

    public TurnAction(GameObject active_Ship, _Engine a_Engine)
    {
        c_Ship = active_Ship;
        c_Eng = a_Engine;
        c_Action = action_Type.Engine;
    }

    public TurnAction(GameObject active_Ship, GameObject target_Ship, _Equipment a_equip)
    {
        c_Ship = active_Ship;
        t_Ship = target_Ship;
        c_Equ = a_equip;
        c_Action = action_Type.Equipment;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public void Action()
    {
        switch (c_Action)
        {
            case action_Type.Weapon:
                //_Weapon cur_Wep = (_Weapon)c_Item; //cast as _weapon to allow for correct syntax and performance issue minimal in turn based combat
                int c_Dam_S = c_Wep.w_Get_Dam_S();
                int c_Dam_H = c_Wep.w_Get_Dam_H();
                Debug.Log(t_Ship.GetComponent<publicShip>().ShipClass.s_Get_Health());
                if (t_Ship != null && c_Ship != null)
                {
                    if (t_Ship.GetComponent<publicShip>().ShipClass.s_Get_Shields() <= 0)
                    {
                        t_Ship.GetComponent<publicShip>().ShipClass.s_Take_Damage(c_Dam_H, true);
                    }
                    else if (t_Ship.GetComponent<publicShip>().ShipClass.s_Get_Health() > 0)
                    {
                        t_Ship.GetComponent<publicShip>().ShipClass.s_Take_Damage(c_Dam_S, false);
                    }
                    else
                    {
                        return;
                    }
                    Debug.Log("Shields = " + t_Ship.GetComponent<publicShip>().ShipClass.s_Get_Shields());
                    Debug.Log("Hull = " + t_Ship.GetComponent<publicShip>().ShipClass.s_Get_Health());
                }
 
                break;
                
            case action_Type.Shield:
                //_Shield cur_Shield = (_Shield)c_Item;
                //int s_boost = 0;
                foreach (_Shield S in c_Ship.GetComponent<publicShip>().ShipClass.s_Shields)
                {
                    S.sh_boost_action(); // fix implementation of shield boosting
                                         //Boosting will provide a quick surge of shields to the player but they will 
                                         //not recieve the turn recharge the following turn
                }
               //IMPLEMENT FUNCTIONALITY TO BOOST REGEN SHIELDS
               break;
            
            case action_Type.Engine:

                /*IMPLEMENT FUNCTIONALITY TO ALLOW FOR AGILITY BOOST THROUGH GREATER ENGINE POWER*/
               break;
                /*
            case action_Type.Equipment:
                IMPLEMENT FUNCTIONALITY TO ALLOW FOR SPECIAL MOVES
                break;
                */
            default:
                break;
        }
    }
}
