using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _Engine : _Item
{
    protected enum e_Class_Enum
    {
        e_Fighter,
        e_Destroyer,
        e_Cruiser,
        e_BattleShip,
        e_Capital
    };

    protected float e_Power;
    protected float e_Boost;
    e_Class_Enum e_Class;

    public float e_Get_Power()
    {
        return e_Power;
    }

    public float e_Get_Boost()
    {
        return e_Boost;
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
