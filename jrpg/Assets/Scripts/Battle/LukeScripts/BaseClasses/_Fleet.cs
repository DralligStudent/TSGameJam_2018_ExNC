﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fleet : MonoBehaviour
{
    public GameObject[] _Ships;

    protected void _Set_Fleet()
    {

        //code to set fleet ->From pre-battle
    }

    protected void _Add_To_Fleet(GameObject n_Ship)
    {
        for(int i = 0; i<=_Ships.Length;i++)
        {
            if (_Ships[i] == null)
            {
                _Ships[i] = n_Ship;
            }
            else
            {
                Debug.Log("Error: No room in fleet");
            }
        }
    }
}
