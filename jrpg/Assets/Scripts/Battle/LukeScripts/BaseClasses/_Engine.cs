using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class _Engine : ScriptableObject
{
    protected enum e_Class_Enum
    {
        e_Null,
        e_Fighter,
        e_Destroyer,
        e_Cruiser,
        e_BattleShip,
        e_Capital
    };

    [SerializeField]
    protected float e_Power, e_Boost, e_Boost_Gain, e_Boost_Max; //Engine output, engine boost value, points added to boost turn, max level of the boost ammount
    [SerializeField]
    e_Class_Enum e_Class = e_Class_Enum.e_Null;
    

    public float e_Get_Power()
    {
        return e_Power;
    }

    public float e_Get_Boost()
    {
        if (e_Boost > (e_Boost_Max * 0.25))
        {
            e_Boost = 0;
            return e_Boost;
        }
        return 0;
    }

    protected void e_Set_Power(int e)
    {
        e_Power = e;
    }

    protected void e_Set_Boost(int e)
    {
        e_Boost = e;
    }

    protected void e_Set_Class(e_Class_Enum n_Class)
    {
        e_Class = n_Class;
    }

}
