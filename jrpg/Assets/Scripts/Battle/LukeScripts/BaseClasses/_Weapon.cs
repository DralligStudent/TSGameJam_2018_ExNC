using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class _Weapon : ScriptableObject
{
    [Tooltip("A weapon Multiplier, BE CAREFUL WHEN SETTING THIS VALUE")]
    [SerializeField]
    protected float w_Damage;
    protected enum w_Class_Enum
    {
        w_Fighter,
        w_Destroyer,
        w_Cruiser,
        w_BattleShip,
        w_Capital
    };

    protected enum w_Type_Enum
    {
        w_Lazer,
        w_Railgun,
        w_Torpedo,
        w_Arti
    };

    [SerializeField]
    protected w_Class_Enum w_Class;
    [SerializeField]
    protected w_Type_Enum w_Type;
    [SerializeField]
    protected int w_Ammo_Cap;

    private int w_Cur_Ammo;

    public _Ammo w_Ammo;

    protected void w_Set_Class(w_Class_Enum n_Class)
    {
        w_Class = n_Class;
    }

    protected void w_Set_Type(w_Type_Enum n_Type)
    {
        w_Type = n_Type;
    }

    protected void w_Set_W_Multi(float x)
    {
        w_Damage = x;
    }
    /*
    public int w_Dam_S
    {
        get
        {
            float a_Dam = w_Ammo.a_Get_Damage() * 0.5f;
            float a_Bias = w_Ammo.a_Get_Bias();

            //a_Bias = Mathf.Clamp01(a_Bias);
            if (a_Bias > 1.0f)
            {
                a_Bias = 1.0f;
            }
            else if (a_Bias < 0.0f)
            {
                a_Bias = 0.0f;
            }

            float n_Bias = 1f - (a_Bias - 0.5f);
            float s_Bias;

            if (a_Bias >= 0.5f)
            {
                s_Bias = 1 + n_Bias;
            }
            else
            {
                s_Bias = 1 - n_Bias;
            }
            /*


            if (a_Bias > 0.5f && a_Bias <= 1.0f)
            {
                a_Dam = a_Dam + a_Dam / n_Bias;
            }
            else
            {
                a_Dam = a_Dam + a_Dam * n_Bias;
            }*/
    /*
    float n_Dam = (float)a_Dam * w_Damage;
    n_Dam += 0.999f; //ensure rounding up when casting into int due to c# stripping decimal rather than rounding

    return (int)n_Dam; //return n_Dam as int so it can be taken from target ship health

}
}*/

    public int w_Check_Ammo()
    {
        return w_Cur_Ammo;
    }

    public int w_Get_Dam_S()
    {
        //return w_Dam_S;
        float a_Dam = w_Ammo.a_Get_Damage() * 0.5f;
        float a_S_Bias = w_Ammo.a_Get_Shield_Bias();

        a_Dam = a_Dam + (a_Dam * a_S_Bias);

        float n_Dam = a_Dam * w_Damage;
        n_Dam += 0.999f; //ensure rounding up when casting into int due to c# stripping decimal rather than rounding

        return (int)n_Dam; //return n_Dam as int so it can be taken from target ship health
    }
    
    public int w_Get_Dam_H()
    {
        float a_Dam = w_Ammo.a_Get_Damage() * 0.5f;
        float a_H_Bias = w_Ammo.a_Get_Hull_Bias();

        a_Dam = a_Dam + (a_Dam * a_H_Bias);

        float n_Dam = a_Dam * w_Damage;
        n_Dam += 0.999f; //ensure rounding up when casting into int due to c# stripping decimal rather than rounding

        return (int)n_Dam; //return n_Dam as int so it can be taken from target ship health
    }
}
