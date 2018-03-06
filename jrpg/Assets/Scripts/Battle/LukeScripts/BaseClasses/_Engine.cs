using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class _Engine : ScriptableObject
{
    protected enum e_Class_Enum
    {
        e_Fighter,
        e_Destroyer,
        e_Cruiser,
        e_BattleShip,
        e_Capital
    };

    [SerializeField]
    protected float e_Power, e_Boost; //Engine output, engine boost value
    [SerializeField]
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
