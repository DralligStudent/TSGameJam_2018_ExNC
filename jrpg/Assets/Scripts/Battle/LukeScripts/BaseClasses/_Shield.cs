﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class _Shield : ScriptableObject
{
    [SerializeField]
    protected int sh_Shield, sh_Recharge, sh_Boost; //The shield health value, the shield recharge rate
    //private int sh_Cur;

    public int sh_Get_Shield()
    {
        return sh_Shield;
    }

    public int sh_Get_Recharge()
    {
        return sh_Recharge;
    }

    protected void sh_Set_Shield(int new_S)
    {
        sh_Shield = new_S;
    }

    protected void sh_Set_Recharge(int new_R)
    {
        sh_Recharge = new_R;
    }

    public void sh_boost_action()
    {
        /*
        sh_Shield += sh_Boost;
        */
    }

    public int sh_Reset()
    {
        /*int sh_Add;
        /*
        if (sh_Shield > sh_Cur)
        {
            sh_Shield = sh_Cur;
        }
        */
        return 1;
    }
}
