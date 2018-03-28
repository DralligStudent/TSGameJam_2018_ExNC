using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fleet : MonoBehaviour
{
    public GameObject[] _Ships =  new GameObject[10];

    protected void _Set_Fleet()
    {

        //code to set fleet ->From pre-battle
    }

    public void _Add_To_Fleet(GameObject n_Ship)
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

    public int get_FleetSize()
    {
        return _Ships.Length;
    }

    public GameObject[] get_Fleet()
    {
        return _Ships;
    }
}
