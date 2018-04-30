using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Fleet : MonoBehaviour
{
    public GameObject[] _ships;

    public void Awake()
    {
        _ships = new GameObject[8];
        Debug.Log("sup");
    }

    protected void _Set_Fleet()
    {

        //code to set fleet ->From pre-battle
    }

    public void _Add_To_Fleet(GameObject n_Ship)
    {
        Debug.Log(n_Ship);
        Debug.Log(_ships.Length);
        for(int i = 0; i < _ships.Length;i++)
        {

            if (_ships[i] == null)
            {
                _ships[i] = n_Ship;
                Debug.Log(_ships[i]);
                return;
            }
            else
            {
                Debug.Log("Error: No room in fleet");
            }
        }
    }
    /*
    public void set_Fleet(int x)
    {

    }*/

    public int get_FleetSize()
    {
        return _ships.Length;
    }

    public GameObject[] get_Fleet()
    {
        return _ships;
    }
}
