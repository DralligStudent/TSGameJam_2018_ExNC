using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class _Ship : ScriptableObject
{
    protected enum _Class
    {
        _Fighter,
        _Destroyer,
        _Cruiser,
        _BattleShip,
        _Capital
    };

    //arrays of ship parts
    public _Engine[] s_Engine;
    public _Shield[] s_Shields;
    public _Weapon[] s_Weapons;
    public _Equipment[] s_Equipment;
    //temporarry storage for array stuff
    private _Engine[] p_s_Engine;
    private _Shield[] p_s_Shields;
    private _Weapon[] p_s_Weapons;
    private _Equipment[] p_s_Equipment;

    //values for each ship
    [SerializeField]
    protected int s_Max_Health, s_Size, s_Agility, s_Weight, s_FP_Value; //Hull Health Value, Size value (millions of m^3), Agility value, Weight Value (thousands of kg), the Ships fleet point value
    [SerializeField]
    protected _Class s_Class; //Class of the ship

    protected int s_Cur_Health; //Current Hull Health
    protected int s_Damage_Taken; //to count damage outside of battle
    protected int s_Shield; //Shield Health Value
    protected float s_Speed; // Speed Value
    protected int s_Xp; //XP value
    protected int s_Level; //Current Ship Level
    protected int s_Shield_Rate; //Amount the shields recharges per tick
    protected int s_Max_Wep; //max number of weapon slots on ship
    protected int s_Max_Sh; // max number of shield slots on ship
    protected int s_Max_Eng; //max number of engine slots on ship
    protected int s_Max_Equip; // max number of equipment slots on ship
    protected int s_Power_Level; //a rating for the ship to be used when determining fleet strength

    protected void s_Calc_Shields()
    {
        int t_Shield_V = 0;
        int t_Shield_R = 0;
        foreach (_Shield Sh in s_Shields)
        {
            if (Sh != null)
            {
                t_Shield_V += Sh.sh_Get_Shield();//get shield value shield
                t_Shield_R += Sh.sh_Get_Recharge();//get the recharge rate of the shield
            }


        }
        s_Shield = t_Shield_V; //set shield value
        s_Shield_Rate = t_Shield_R; //set recharge rate
    }

    protected void s_Calc_Speed() //generates the s_Speed value for the ship
    {
        float e_pow = 0;
        foreach (_Engine E in s_Engine) //access the engine array
        {
            if(E != null)
            {
                e_pow += E.e_Get_Power();
            }

        }
        float n_speed = e_pow / s_Weight; //this means that speed will always be > 1
        s_Speed = n_speed; //set speed
    }

    protected void s_Calc_Values(int _health, int _size, int _agility, int _weight, int _max_wep, int _max_shield, int _max_eng, int _max_equip)
    {
        //this is the first function that should be called inside of a ship, setting the vital values for each of the following attributes
        s_Max_Health = _health;
        s_Size = _size;
        s_Weight = _weight;
        s_Agility = _agility;
        s_Max_Wep = _max_wep;
        s_Max_Sh = _max_shield;
        s_Max_Eng = _max_eng;
        s_Max_Equip = _max_equip;
        s_Set_Arrays(_max_eng, _max_shield, s_Max_Wep, _max_equip);
        s_Cur_Health = s_Max_Health - s_Damage_Taken;
    }

    protected void s_Call() //output all of the values in the ship to the debug
    {
        Debug.Log("Health = " + s_Cur_Health);
        Debug.Log("Shield = " + s_Shield);
        Debug.Log("Speed = " + s_Speed);
        Debug.Log("XP = " + s_Xp);
        Debug.Log("Size = " + s_Size);
        Debug.Log("Agility = " + s_Agility);
        Debug.Log("Weight = " + s_Weight);
        Debug.Log("Shiled Rate = " + s_Shield_Rate);
    }

    protected void s_Set_Arrays(int _En, int _Sh, int _W, int _Eq)
    {
        //this should be the second function called within a ship OR if we have the ability to modify a ships core values.

        //set engine array size
        if (_En > 0 && _En <= 4 && _En <= s_Max_Eng)
        {
            s_Engine = new _Engine[_En];
        }

        //set shield array size
        if (_Sh > 0 && _Sh <= 4 && _Sh <= s_Max_Sh)
        {
            s_Shields = new _Shield[_Sh];
        }

        //set weapon array size
        if (_W >= 0 && _W <= 4 && _W <= s_Max_Wep)
        {
            s_Weapons = new _Weapon[_W];
        }

        //set equipment array size
        if (_Eq >= 0 && _Eq <= 10 && _Eq <= s_Max_Equip)
        {
            s_Equipment = new _Equipment[_Eq];
        }
    }

    /*
    protected void s_Calc_PLevel()
    {

    }*/

    public _Weapon s_Get_Weapon(int x)
    {
        return s_Weapons[x];
    }

    public void s_Take_Damage(int x, bool a)//if true, do damage to hull. else do damage to shield
    {
        if (a)
        {
            s_Cur_Health -= x;
            s_Damage_Taken += x;
        }
        else
        {
            s_Shield -= x;
            if (s_Shield <= 0)
            {
                s_Shield = 0;
            }
        }
    }

    public int s_Get_Health()
    {
        return s_Cur_Health;
    }

    public int s_Get_Shields()
    {
        return s_Shield;
    }

    public float s_Get_Speed()
    {
        return s_Speed;
    }
}
